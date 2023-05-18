using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IMetaRepository : IDisposable
    {
        void Insert(Meta meta);

        void Update(Meta meta);

        PagedResult<Meta> Get(MetaParameters parameters);

        Meta? GetByKey(MetaParameters parameters);

        void Remove(Meta meta);

        void Save();
    }
}
