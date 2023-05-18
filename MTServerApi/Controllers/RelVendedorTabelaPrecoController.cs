using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;
using System.Data;

namespace mtvendors_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RelVendedorTabelaPrecoController : Controller
    {
        private IRelVendedorTabelaPrecoRepository _repository;

        public RelVendedorTabelaPrecoController(DataContext context)
        {
            _repository = new RelVendedorTabelaPrecoRepository(context);
        }

        [HttpPost("Create")]
        public ActionResult Create([Bind(include: "FkEmpresa, FkVendedor, FkTabelaPreco")] RelVendedorTabelaPreco relacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var relacaodb = _repository.GetByKey(new RelVendedorTabelaPreco
                    {
                        FkEmpresa = relacao.FkEmpresa,
                        FkVendedor = relacao.FkVendedor,
                        FkTabelaPreco = relacao.FkTabelaPreco
                    });

                    if (relacaodb != null)
                    {
                        return BadRequest("O recurso que você tentou adicionar já existe");
                    }

                    _repository.Insert(relacao);
                    _repository.Save();
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
        public RelVendedorTabelaPreco? GetByKey([FromQuery] RelVendedorTabelaPreco relacao)
        {
            return _repository.GetByKey(relacao);
        }

        [HttpGet("Get")]
        public PagedResult<RelVendedorTabelaPreco> Get([FromQuery] RelacaoParameters parameters)
        {
            return _repository.Get(parameters);
        }

        [HttpDelete("Remove")]
        public ActionResult Remove([FromQuery] RelVendedorTabelaPreco relacao)
        {
            try
            {
                var relacaodb = _repository.GetByKey(relacao);
                if (relacaodb == null)
                {
                    return BadRequest("O recurso que você tentou excluir não existe");
                }

                _repository.Remove(relacaodb);
                _repository.Save();

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
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
