using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface ISituacaoRepository : IDisposable
    {
        void Insert(SituacaoPedido situacao);

        void Update(SituacaoPedido situacao);

        PagedResult<SituacaoPedido> Get(SituacaoPedidoParameters parameters);

        SituacaoPedido? GetByCodigo(int codigo);

        void Remove(int codigo);

        void Save();
    }
}
