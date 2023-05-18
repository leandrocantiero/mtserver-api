using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using System.Data;
using mtvendors_api.Models.parameters;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;

namespace mtvendors_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SituacaoPedidoController : Controller
    {
        private ISituacaoRepository situacaoRepository;

        public SituacaoPedidoController(DataContext context)
        {
            situacaoRepository = new SituacaoRepository(context);
        }

        [HttpPost("Create")]
        public ActionResult Create([Bind(include: "Codigo, Descricao")] SituacaoPedido situacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var situacaodb = situacaoRepository.Get(new SituacaoPedidoParameters
                    {
                        Descricao = situacao.Descricao,
                    });
                    if (situacaodb.Data.Count() > 0)
                    {
                        return BadRequest("O recurso que você tentou adicionar já existe");
                    }

                    situacaoRepository.Insert(situacao);
                    situacaoRepository.Save();
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
        public ActionResult Edit([Bind(include: "Codigo, Descricao")] SituacaoPedido situacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    situacaoRepository.Update(situacao);
                    situacaoRepository.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (DataException e)
            {
                ModelState.AddModelError(e.Message, "Não foi possivel concluir a operação");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        [HttpGet("GetByCodigo")]
        public SituacaoPedido? GetByCodigo([FromQuery] int codigo)
        {
            return situacaoRepository.GetByCodigo(codigo);
        }

        [HttpGet("Get")]
        public PagedResult<SituacaoPedido> Get([FromQuery] SituacaoPedidoParameters parameters)
        {
            return situacaoRepository.Get(parameters);
        }

        [HttpDelete("Remove")]
        public ActionResult Remove([FromQuery] int codigo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var situacaodb = situacaoRepository.GetByCodigo(codigo);
                    if (situacaodb == null)
                    {
                        return BadRequest("O recurso que você tentou excluir não existe");
                    }

                    situacaoRepository.Remove(codigo);
                    situacaoRepository.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (DataException e)
            {
                ModelState.AddModelError(e.Message, "Não foi possivel concluir a operação");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            situacaoRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}