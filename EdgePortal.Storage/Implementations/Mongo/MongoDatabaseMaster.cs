using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using EdgePortal.Model.Blog;

namespace EdgePortal.Storage.Implementations.Mongo
{
    internal class MongoDatabaseMaster
    {
        // private const string ACCOUNTS_COLLECTION = "Accounts";
        private const string BLOG_COLLECTION = "Blog";

        private readonly IMongoDatabase _database;

        internal MongoDatabaseMaster(IMongoDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _database = database;            
        }

        // internal IMongoCollection<MongoDBAccount> Accounts => _database.GetCollection<MongoDBAccount>(ACCOUNTS_COLLECTION);

        internal IMongoCollection<PostModel> Blog => _database.GetCollection<PostModel>(BLOG_COLLECTION);
    }
}