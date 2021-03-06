﻿using System;
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
                throw new ArgumentNullException(nameof(database) + " cannot be null");

            _database = database;

            BsonClassMap.RegisterClassMap<BaseDocumentModel>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }

        public Task<PostModel> AddPost(PostModel post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post) + " cannot be null");

            post.CreationTime = DateTime.UtcNow;

            return Task<PostModel>.Run(async () => { await _database.Blog.InsertOneAsync(post); return post; });
        }

        public Task<PostModel> FindPost(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException(nameof(id) + " cannot be null or empty");

            return _database.Blog.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public Task<bool> DeletePost(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException(nameof(id) + " cannot be null or empty");

            return Task.Run(async () => {

                DeleteResult res = await _database.Blog.DeleteOneAsync(x => x.Id == id);
                return res.DeletedCount > 0;
            });
        }

        public Task<List<PostModel>> GetAllPosts()
        {
            return GetPostsInt(-1);
        }

        public Task<List<PostModel>> GetPosts(int recordCount)
        {
            if (recordCount < 0)
                throw new ArgumentException(nameof(recordCount) + " cannot be less than zero");

            return GetPostsInt(recordCount);
        }

        public Task<List<PostModel>> GetUserPosts(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException(nameof(userName) + " cannot be null");

            return _database.Blog.Find(x => x.Author == userName).ToListAsync();
        }    
        
        private Task<List<PostModel>> GetPostsInt(int recordCount)
        {
            return _database.Blog.Find(new BsonDocument()).
                                        SortByDescending(x => x.CreationTime).
                                            Limit(recordCount < 0 ? null : (int?)recordCount).ToListAsync();
        }
    }
}