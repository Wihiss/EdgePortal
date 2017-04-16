using EdgePortal.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgePortal.Storage.Interfaces.Blog
{
    public interface IBlogManager
    {
        Task<List<PostModel>> GetAllPosts();
        Task<List<PostModel>> GetPosts(int recordCount);
        Task<List<PostModel>> GetUserPosts(string userName);
        Task<PostModel> AddPost(PostModel post);
        Task<PostModel> FindPost(string postId);
        Task<bool> DeletePost(string postId);
    }
}
