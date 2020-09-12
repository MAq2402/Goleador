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

    public class GoogleBooksApiSettings
    {
        public GoogleBooksApiSettings(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }

    public class Settings
    {
        public Settings(MongoSettings mongoSettings, GoogleBooksApiSettings googleBooksApiSettings)
        {
            MongoSettings = mongoSettings;
            GoogleBooksApiSettings = googleBooksApiSettings;
        }

        public MongoSettings MongoSettings { get; }
        public GoogleBooksApiSettings GoogleBooksApiSettings { get; }
    }
}