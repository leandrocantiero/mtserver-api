using mtvendors_api.Models.DTO;
using mtvendors_api.Models.Helpers;

namespace mtvendors_api.DAL.IRepository
{
    public interface IDatabaseRepository
    {
        void Set(DatabaseConnDTO databaseConn);

        DatabaseConnDTO Get();

        void SaveSchema(DataContext context, Schema schema);

        bool CreateDatabase(DatabaseConnDTO databaseConn);
    }
}
