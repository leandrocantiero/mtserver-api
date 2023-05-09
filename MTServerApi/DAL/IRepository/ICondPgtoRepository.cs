using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface ICondPgtoRepository : IDisposable
    {
        PagedResult<CondPgto> Get(CondPgtoParameters parameters);
    }
}
