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
    public class CondPgtoController : ControllerBase
    {
        private ICondPgtoRepository _repository;

        public CondPgtoController(DataContext context)
        {
            _repository = new CondPgtoRepository(context);
        }

        [HttpGet("Get")]
        public PagedResult<CondPgto> Get([FromQuery] CondPgtoParameters parameters)
        {
            return _repository.Get(parameters);
        }
    }
}
