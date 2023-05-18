using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IRelVendedorTabelaPrecoRepository : IDisposable
    {
        void Insert(RelVendedorTabelaPreco relacao);

        PagedResult<RelVendedorTabelaPreco> Get(RelacaoParameters parameters);

        RelVendedorTabelaPreco? GetByKey(RelVendedorTabelaPreco relacao);

        void Remove(RelVendedorTabelaPreco relacao);

        void Save();
    }
}
