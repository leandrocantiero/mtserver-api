using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface ITabelaPrecoRepository : IDisposable
    {
        PagedResult<TabelaPreco> Get(TabelaPrecoParameters parameters);
    }
}
