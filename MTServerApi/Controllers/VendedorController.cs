using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL;
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
    public class VendedorController : Controller
    {
        private IVendedorRepository _repository;

        public VendedorController(DataContext context)
        {
            _repository = new VendedorRepository(context);
        }

        [HttpPut("Edit")]
        public ActionResult Edit([Bind(include: "Codigo, Nome")] Vendedor vendedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(vendedor);
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
                ModelState.AddModelError(e.Message, "Não foi possivel concluir a operação");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
        }

        [HttpGet("Get")]
        public PagedResult<Vendedor> Get([FromQuery] VendedorParameters parameters)
        {
            return _repository.Get(parameters);
        }

        [HttpGet("GetByCodigo")]
        public Vendedor? GetByCodigo([FromQuery] string codigo)
        {
            return _repository.GetByCodigo(codigo);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
