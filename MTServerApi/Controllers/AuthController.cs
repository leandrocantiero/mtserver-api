using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using mtvendors_api.DAL;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.parameters;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace mtvendors_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private IVendedorRepository vendedorRepository;

        public AuthController(DataContext context)
        {
            vendedorRepository = new VendedorRepository(context);
        }

        private static string GetToken(string codigo)
        {
            var key = AppSettings.GetValue("JwtSecretKey");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, codigo)
                }),
                Expires = DateTime.UtcNow.AddMinutes(240),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("SignIn")]
        public ActionResult<Vendedor> SignIn([Bind(include: "Codigo, Senha")] Vendedor vendedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vendedordb = vendedorRepository.GetByAuth(vendedor.Codigo, vendedor.Senha);
                    if (vendedordb != null)
                    {
                        vendedordb.Token = GetToken(vendedor.Codigo);
                        vendedordb.Senha = "";
                        return Ok(vendedordb);
                    }
                    else
                    {
                        return BadRequest("Usuário ou Senha inválidos");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (DataException e)
            {
                ModelState.AddModelError(e.Message, "Não foi possível concluir a operação, tente novamente mais tarde");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp([Bind(include: "Nome, Email, Senha")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                var vendedordb = vendedorRepository.Get(new VendedorParameters
                {
                    Nome = vendedor.Nome,
                    Email = vendedor.Email
                });
                if (vendedordb.Data.Count() > 0)
                {
                    return BadRequest("O recurso que você tentou adicionar já existe, tente usar outro nome");
                }

                vendedorRepository.Insert(vendedor);
                vendedorRepository.Save();
                return Ok(vendedor);

                //ModelState.AddModelError("Não foi possível concluir a operação, tente novamente mais tarde", e.Message);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("ValidateToken")]
        public ActionResult<bool> ValidateToken([Bind(include: "Nome, Token")] Vendedor vendedor)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(vendedor.Token, validationParameters, out validatedToken);

                if (principal.Identity == null)
                    return false;

                return principal.Identity.IsAuthenticated;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.GetValue("JwtSecretKey"))) // The same key as the one that generate the token
            };
        }

        protected override void Dispose(bool disposing)
        {
            vendedorRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
