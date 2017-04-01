using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using EdgePortal.Storage.Interfaces.Blog;
using EdgePortal.Model;
using EdgePortal.Model.Blog;

namespace EdgePortal.Storage.Implementations.Mongo
{
    internal class MongoBlogManager : IBlogManager
    {
        private readonly MongoDatabaseMaster _database;

        internal MongoBlogManager(MongoDatabaseMaster database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _database = database;

            BsonClassMap.RegisterClassMap<BaseDocumentModel>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }

        public Task<PostModel> AddPost(PostModel post)
        {
            return Task<PostModel>.Run(async () => { await _database.Blog.InsertOneAsync(post); return post; });
        }

        public Task<PostModel> FindPost(string id)
        {            
            return _database.Blog.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public Task DeletePost(string id)
        {
            return _database.Blog.DeleteOneAsync(x => x.Id == id);
        }

        public Task<List<PostModel>> GetPosts(int recordCount)
        {
            return _database.Blog.Find(new BsonDocument()).
                                        SortByDescending(x => x.CreationTime).
                                            Limit(recordCount < 0 ? null : (int?) recordCount).ToListAsync();
        }

        public Task<List<PostModel>> GetUserPosts(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException(nameof(userName));

            return _database.Blog.Find(x => x.Author == userName).ToListAsync();
        }
    }
}