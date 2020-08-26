using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.Types
{
    public class MongoSettings
    {
        public MongoSettings(string connectionString, string dbName)
        {
            ConnectionString = connectionString;
            DbName = dbName;
        }

        public string ConnectionString { get; }

        public string DbName { get; }
    }

    public class Settings
    {
        public Settings(MongoSettings mongoSettings)
        {
            MongoSettings = mongoSettings;
        }

        public MongoSettings MongoSettings { get; }
    }
}
