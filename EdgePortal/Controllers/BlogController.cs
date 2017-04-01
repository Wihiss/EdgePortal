using EdgePortal.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EdgePortal.Api.Controllers
{
    [RoutePrefix("api/blog")]
    public class BlogController : StorageBasedController
    {
        [HttpGet]
        [Route("posts")]
        public async Task<IHttpActionResult> GetPosts()
        {
            return Ok(await _storage.BlogManager.GetPosts(-1));            
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddPost(PostModel post)
        {
            return Ok(await _storage.BlogManager.AddPost(post));
        }

        [HttpGet]
        [Route("posts/{postId}")]
        public async Task<IHttpActionResult> GetPost(string postId)
        {
            PostModel post = await _storage.BlogManager.FindPost(postId);
            if (post == null)
                return NotFound();
            
            return Ok(post);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletePost(string postId)
        {
            await _storage.BlogManager.DeletePost(postId);
            return Ok();
        }
    }
}
