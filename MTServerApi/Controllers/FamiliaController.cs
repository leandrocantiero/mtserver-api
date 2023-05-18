using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        private IFamiliaRepository familiaProdutoRepository;

        public FamiliaController(DataContext context)
        {
            familiaProdutoRepository = new FamiliaRepository(context);
        }

        [HttpGet("Get")]
        public PagedResult<FamiliaProduto> Get([FromQuery] ProdutoParameters parameters)
        {
            return familiaProdutoRepository.Get(parameters);
        }

        [HttpGet("GetByCodigo")]
        public FamiliaProduto GetByCodigo([FromQuery] string codigo)
        {
            return familiaProdutoRepository.GetByCodigo(codigo);
        }
    }
}
