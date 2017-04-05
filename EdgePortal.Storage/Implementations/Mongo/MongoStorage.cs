using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;
using EdgePortal.Storage.Implementations.Mongo;
using EdgePortal.Storage.Interfaces.Blog;
using EdgePortal.Storage.Interfaces;

namespace FamilyPortal.Storage.Impl.Mongo
{
    internal class MongoStorage : IStorage
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        
        private readonly Lazy<MongoDatabaseMaster> _databaseMaster;
        // private readonly Lazy<IAccountManager> _accountManager;
        private readonly Lazy<IBlogManager> _blogManager;

        public MongoStorage(/*IPasswordHasher passwordHasher*/string dbConnection)
        {
            if (string.IsNullOrEmpty(dbConnection))
                throw new ArgumentException(nameof(dbConnection) + " cannot be null or empty");

            /*if (passwordHasher == null)
                throw new ArgumentNullException(nameof(passwordHasher));*/

            var urlBuilder = new MongoUrlBuilder(dbConnection);

            _client = new MongoClient(urlBuilder.ToMongoUrl());

            _database = _client.GetDatabase(urlBuilder.DatabaseName);

            _databaseMaster = new Lazy<MongoDatabaseMaster>(() => new MongoDatabaseMaster(_database));

            // _accountManager = new Lazy<IAccountManager>(() => new MongoDBAccountManager(_familyDatabase.Value, passwordHasher));

            _blogManager = new Lazy<IBlogManager>(() => new MongoBlogManager(_databaseMaster.Value));
        }

        // IAccountManager IStorage.AccountManager => _accountManager.Value;

        IBlogManager IStorage.BlogManager => _blogManager.Value;

        public void Dispose()
        {
        }        
    }
}