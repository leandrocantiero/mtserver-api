using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IEmpresaRepository : IDisposable
    {
        PagedResult<Empresa> GetEmpresas(EmpresaParameters parameters);

        Empresa? GetEmpresaByCodigo(string codigo);

        PagedResult<Filial> GetFiliais(EmpresaParameters parameters);

        Filial? GetFilialByCodigo(string codigo);
    }
}
