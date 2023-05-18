using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IRelFilialCondPgtoRepository : IDisposable
    {
        void Insert(RelFilialCondPgto relacao);

        void Update(RelFilialCondPgto relacao);

        PagedResult<RelFilialCondPgto> Get(RelacaoParameters parameters);

        RelFilialCondPgto? GetByKey(RelFilialCondPgto relacao);

        void Remove(RelFilialCondPgto relacao);

        void Save();
    }
}
