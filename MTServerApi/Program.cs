using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using mtvendors_api;
using mtvendors_api.DAL;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models.DTO;
using mtvendors_api.Models.Helpers;
using Serilog;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownProxies.Add(IPAddress.Parse("192.168.0.101"));
});

builder.Services.AddDbContext<DataContext>(opt =>
{
    var connectionString = AppSettings.GetValue("ConnectionString");
    if (!string.IsNullOrEmpty(connectionString))
    {
        opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
});
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo { Title = "MTServerApi", Version = "v1" });

    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme",
    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
    } });
});
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    var key = AppSettings.GetValue("JwtSecretKey");
    var keyBytes = Encoding.ASCII.GetBytes(key);

    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});
builder.Logging.AddSerilog(new LoggerConfiguration()
    .WriteTo.File(Path.Combine(AppContext.BaseDirectory, "logs\\api-{Date}.log"), rollingInterval: RollingInterval.Day)
    .CreateLogger());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseForwardedHeaders();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin 
    .AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    if (context != null && context.Database.CanConnect())
    {
        var conn = new DatabaseConnDTO(AppSettings.GetValue("ConnectionString"));
        
        try
        {
            // Atualização automática
            context.Database.Migrate();
            new DatabaseRepository().SaveSchema(context, DBConverter.GetDatabaseSchema(conn.DatabaseName));
        }
        catch (Exception ex)
        {
            // Atualização automática não suportada
        }
    }
}