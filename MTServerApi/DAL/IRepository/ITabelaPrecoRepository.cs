using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface ITabelaPrecoRepository : IDisposable
    {
        PagedResult<TabelaPreco> Get(TabelaPrecoParameters parameters);
    }
}
