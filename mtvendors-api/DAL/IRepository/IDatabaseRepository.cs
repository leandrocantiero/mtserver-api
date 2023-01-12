﻿using mtvendors_api.Models;

namespace mtvendors_api.DAL.IRepository
{
    public interface IDatabaseRepository
    {
        void Set(DatabaseConn databaseConn);

        DatabaseConn Get();

        void CreateDatabase();
    }
}
