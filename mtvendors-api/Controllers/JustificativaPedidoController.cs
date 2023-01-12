using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JustificativaPedidoController : Controller
    {
        private IJustificativaRepository justificativaRepository;

        public JustificativaPedidoController(DataContext context)
        {
            justificativaRepository = new JustificativaRepository(context);
        }

        [HttpPost("Create")]
        public ActionResult Create([Bind(include: "Codigo, Descricao")] JustificativaPedido justificativa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var justificativadb = justificativaRepository.Get(new JustificativaPedidoParameters
                    {
                        Descricao = justificativa.Descricao,
                    });
                    if (justificativadb.Data.Count() > 0)
                    {
                        return BadRequest("O recurso que você tentou adicionar já existe");
                    }

                    justificativaRepository.Insert(justificativa);
                    justificativaRepository.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel concluir a operação");
            }
        }

        [HttpPut("Edit")]
        public ActionResult Edit([Bind(include: "Codigo, Descricao")] JustificativaPedido justificativa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    justificativaRepository.Update(justificativa);
                    justificativaRepository.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel concluir a operação");
            }
        }

        [HttpGet("GetByCodigo")]
        public JustificativaPedido? GetByCodigo(int Codigo)
        {
            return justificativaRepository.GetByCodigo(Codigo);
        }

        [HttpGet("Get")]
        public PagedResult<JustificativaPedido> Get([FromQuery] JustificativaPedidoParameters parameters)
        {
            return justificativaRepository.Get(parameters);
        }

        [HttpDelete("Remove")]
        public ActionResult Remove([FromQuery] int codigo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var justificativadb = justificativaRepository.GetByCodigo(codigo);
                    if (justificativadb == null)
                    {
                        return BadRequest("O recurso que você tentou excluir não existe");
                    }

                    justificativaRepository.Remove(codigo);
                    justificativaRepository.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel concluir a operação");
            }
        }

        protected override void Dispose(bool disposing)
        {
            justificativaRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
