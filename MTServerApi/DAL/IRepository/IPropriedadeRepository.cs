using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IPropriedadeRepository : IDisposable
    {
        void Update(Propriedade propriedade);

        PagedResult<Propriedade> Get(PropriedadeParameters parameters);

        Propriedade? GetByNome(string nome);

        void Save();
    }
}
