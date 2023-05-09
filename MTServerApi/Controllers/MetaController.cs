using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;
using System.Data;

namespace mtvendors_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MetaController : Controller
    {
        private IMetaRepository metaRepository;

        public MetaController(DataContext context)
        {
            metaRepository = new MetaRepository(context);
        }

        [HttpPost("Create")]
        public ActionResult Create([Bind(include: "FkFilial, FkVendedor, FkProduto, FkFamilia, FkClienteCnpjCpf, Periodo, Quantidade, Valor")] Meta meta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metadb = metaRepository.GetByKey(new MetaParameters
                    {
                        FkClienteCnpjCpf = meta.FkClienteCnpjCpf,
                        FkFilial = meta.FkFilial,
                        FkVendedor = meta.FkVendedor,
                        FkProduto = meta.FkProduto,
                        FkFamilia = meta.FkFamilia
                    });

                    if (metadb != null)
                    {
                        return BadRequest("O recurso que você tentou adicionar já existe");
                    }

                    metaRepository.Insert(meta);
                    metaRepository.Save();
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

        [HttpPut("Edit")]
        public ActionResult Edit([Bind(include: "FkFilial, FkVendedor, FkProduto, FkFamilia, FkClienteCnpjCpf, Periodo, Quantidade, Valor")] Meta meta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    metaRepository.Update(meta);
                    metaRepository.Save();
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

        [HttpGet("GetByKey")]
        public Meta? GetByKey([FromQuery] MetaParameters parameters)
        {
            if (parameters.IsParametersValid)
            {
                return metaRepository.GetByKey(parameters);
            }
            else
            {
                return null;
            }
        }

        [HttpGet("Get")]
        public PagedResult<Meta> Get([FromQuery] MetaParameters parameters)
        {
            return metaRepository.Get(parameters);
        }

        [HttpDelete("Remove")]
        public ActionResult Remove([FromQuery] int FkFilial, string FkVendedor, string FkClienteCnpjCpf, string FkProduto, string FkFamilia)
        {
            try
            {
                var metadb = metaRepository.GetByKey(new MetaParameters
                {
                    FkClienteCnpjCpf = FkClienteCnpjCpf,
                    FkFilial = FkFilial,
                    FkVendedor = FkVendedor,
                    FkProduto = FkProduto,
                    FkFamilia = FkFamilia
                });
                if (metadb == null)
                {
                    return BadRequest("O recurso que você tentou excluir não existe");
                }

                metaRepository.Remove(metadb);
                metaRepository.Save();

                return NoContent();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel concluir a operação");
            }
        }

        protected override void Dispose(bool disposing)
        {
            metaRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
