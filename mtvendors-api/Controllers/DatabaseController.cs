using Microsoft.AspNetCore.Mvc;
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

        public DatabaseController(DataContext context) {
            databaseRepository = new DatabaseRepository(context);
        }

        [HttpPost("Set")]
        public ActionResult Set([Bind(include: "Host, User, Password, DatabaseName")] DatabaseConn conn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    databaseRepository.Set(conn);
                    return Ok();
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
        public DatabaseConn? Get()
        {
            return databaseRepository.Get();
        }

        [HttpPost("Create")]
        public ActionResult Create([Bind(include: "Host, User, Password, DatabaseName")] DatabaseConn conn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    databaseRepository.Set(conn);
                    databaseRepository.CreateDatabase();
                    return Ok();
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
    }
}
