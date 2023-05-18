using mtvendors_api.Models.DTO;

namespace mtvendors_api.DAL.IRepository
{
    public interface IDatabaseRepository
    {
        void Set(DatabaseConnDTO databaseConn);

        DatabaseConnDTO Get();

        SincronizacaoDTO? GetDatabaseSchema(DatabaseConnDTO databaseConn);

        bool CreateDatabase(DatabaseConnDTO databaseConn);
    }
}
