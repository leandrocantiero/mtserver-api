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
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository empresaRepository;

        public EmpresaController(DataContext context)
        {
            empresaRepository = new EmpresaRepository(context);
        }

        [HttpGet("GetEmpresas")]
        public PagedResult<Empresa> GetEmpresas([FromQuery] EmpresaParameters parameters)
        {
            return empresaRepository.GetEmpresas(parameters);
        }

        [HttpGet("GetEmpresaByCodigo")]
        public Empresa? GetEmpresaByCodigo([FromQuery] string codigo)
        {
            return empresaRepository.GetEmpresaByCodigo(codigo);
        }

        [HttpGet("GetFiliais")]
        public PagedResult<Filial> GetFiliais([FromQuery] EmpresaParameters parameters)
        {
            return empresaRepository.GetFiliais(parameters);
        }

        [HttpGet("GetFilialByCodigo")]
        public Filial? GetFilialByCodigo([FromQuery] string codigo)
        {
            return empresaRepository.GetFilialByCodigo(codigo);
        }
    }
}
