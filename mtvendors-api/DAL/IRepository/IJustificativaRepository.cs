using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IJustificativaRepository : IDisposable
    {
        void Insert(JustificativaPedido justificativa);

        void Update(JustificativaPedido justificativa);

        PagedResult<JustificativaPedido> Get(JustificativaPedidoParameters parameters);

        JustificativaPedido? GetByCodigo(int codigo);

        void Remove(int codigo);

        void Save();
    }
}
