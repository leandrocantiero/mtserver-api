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
    public class ClienteController : ControllerBase
    {
        private IClienteRepository clienteRepository;

        public ClienteController(DataContext context)
        {
            clienteRepository = new ClienteRepository(context);
        }

        [HttpGet("Get")]
        public PagedResult<Cliente> Get([FromQuery] ClienteParameters parameters)
        {
            return clienteRepository.Get(parameters);
        }

        [HttpGet("GetByCodigo")]
        public Cliente? GetByCodigo([FromQuery] string codigo)
        {
            return clienteRepository.GetByCodigo(codigo);
        }
    }
}
