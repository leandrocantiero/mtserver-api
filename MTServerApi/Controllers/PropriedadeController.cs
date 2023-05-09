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
    public class PropriedadeController : Controller
    {
        private IPropriedadeRepository propriedadeRepository;

        public PropriedadeController(DataContext context)
        {
            propriedadeRepository = new PropriedadeRepository(context);
        }

        [HttpPut("Edit")]
        public ActionResult Edit([Bind(include: "Nome, Descricao, Valor, Sequencia")] Propriedade propriedade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    propriedadeRepository.Update(propriedade);
                    propriedadeRepository.Save();
                    return Ok();
                } else
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

        [HttpGet("Get")]
        public PagedResult<Propriedade> Get([FromQuery] PropriedadeParameters parameters)
        {
            return propriedadeRepository.Get(parameters);
        }

        [HttpGet("GetByNome")]
        public Propriedade? GetByNome([FromQuery] string nome)
        {
            return propriedadeRepository.GetByNome(nome);
        }

        protected override void Dispose(bool disposing)
        {
            propriedadeRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
