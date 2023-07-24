using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models.DTO;
using mtvendors_api.Models.Helpers;
using System.Text.Json;

namespace mtvendors_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SincronizacaoController : ControllerBase
    {
        ISincronizacaoRepository repository;
        public SincronizacaoController(DataContext context)
        {
            repository = new SincronizacaoRepository(context);
        }

        [HttpGet("Get")]
        public ActionResult<SincronizacaoDTO> Get([FromQuery] bool databaseFileExists) {
            var sysConfig = repository.GetSysConfig();
            if (sysConfig != null)
            {
                var schema = JsonSerializer.Deserialize(sysConfig.Schema, typeof(Schema)) as Schema;
                var data = repository.GetData(databaseFileExists);

                return Ok(new { sysConfig.Version, Schema = schema, Data = data });
            }

            return BadRequest("Não foi possível recuperar a configuração do sistema");
        }
    }
}