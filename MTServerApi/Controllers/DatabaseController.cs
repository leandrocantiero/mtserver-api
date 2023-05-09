using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models;
using System.Data;

namespace mtvendors_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private IDatabaseRepository databaseRepository;

        public DatabaseController(DataContext context)
        {
            databaseRepository = new DatabaseRepository(context);
        }

        [Authorize]
        [HttpPost("Set")]
        public ActionResult Set([Bind(include: "Host, User, Password, DatabaseName")] DatabaseConn conn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ValidateConn(conn))
                    {
                        databaseRepository.Set(conn);
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Não foi possível realizar a conexão!");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel concluir a operação");
            }
        }

        [HttpGet("Get")]
        public ActionResult<DatabaseConn?> Get()
        {
            return databaseRepository.Get();
        }

        [Authorize]
        [HttpGet("GetDatabaseStructure")]
        public ActionResult<string> GetDatabaseStructure()
        {
            return databaseRepository.GetDatabaseStructure();
        }

        [HttpPost("Create")]
        public ActionResult Create([Bind(include: "Host, User, Password, DatabaseName")] DatabaseConn conn)
        {
            if (ModelState.IsValid)
            {
                if (ValidateConn(conn))
                {
                    return BadRequest("Ops! Parece que a base já existe");
                }
                else
                {
                    if (databaseRepository.CreateDatabase(conn))
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível concluir a operação");
                    }
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private bool ValidateConn(DatabaseConn conn)
        {
            var connectionString = conn.ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            using (DataContext dbContext = new DataContext(optionsBuilder.Options))
            {
                return dbContext.Database.CanConnect();
            }
        }
    }
}
