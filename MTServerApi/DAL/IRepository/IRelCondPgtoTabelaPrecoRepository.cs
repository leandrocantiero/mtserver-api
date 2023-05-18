using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IRelCondPgtoTabelaPrecoRepository : IDisposable
    {
        void Insert(RelCondPgtoTabelaPreco relacao);

        PagedResult<RelCondPgtoTabelaPreco> Get(RelacaoParameters parameters);

        RelCondPgtoTabelaPreco? GetByKey(RelCondPgtoTabelaPreco relacao);

        void Remove(RelCondPgtoTabelaPreco relacao);

        void Save();
    }
}
