using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL;
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
    public class TabelaPrecoController : ControllerBase
    {
        private ITabelaPrecoRepository _repository;

        public TabelaPrecoController(DataContext context)
        {
            _repository = new TabelaPrecoRepository(context);
        }

        [HttpGet("Get")]
        public PagedResult<TabelaPreco> Get([FromQuery] TabelaPrecoParameters parameters)
        {
            return _repository.Get(parameters);
        }
    }
}
