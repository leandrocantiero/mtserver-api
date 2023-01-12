using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using Newtonsoft.Json;

namespace mtvendors_api.DAL.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private DataContext context;

        public DatabaseRepository(DataContext context)
        {
            this.context = context;
        }

        public DatabaseConn? Get()
        {
            var connectionString = AppSettings.GetValue("ConnectionString");

            if (string.IsNullOrEmpty(connectionString))
                return null;

            return new DatabaseConn(connectionString);
        }

        public void Set(DatabaseConn databaseConn)
        {
            AppSettings.SetValue("ConnectionString", databaseConn.ConnectionString);
        }

        public void CreateDatabase()
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}
