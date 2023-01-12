using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IFamiliaRepository : IDisposable
    {
        PagedResult<FamiliaProduto> Get(QueryStringParameters parameters);

        FamiliaProduto? GetByCodigo(string codigo);
    }
}
