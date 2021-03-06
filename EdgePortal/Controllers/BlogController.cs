﻿using EdgePortal.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EdgePortal.Controllers
{
    /// <summary>
    /// BlogController class. Defines WebApi methods for "The Blog" functionality. 
    /// </summary>
    [RoutePrefix("api/blog")]
    public class BlogController : StorageBasedController
    {
        /// <summary>
        /// Returns all posts of the blog.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getPosts")]
        public async Task<IHttpActionResult> GetPosts()
        {
            return Ok(await _storage.BlogManager.GetAllPosts());
        }

        [HttpPost]
        [Route("addPost")]
        public async Task<IHttpActionResult> AddPost(PostModel post)
        {
            return Ok(await _storage.BlogManager.AddPost(post));
        }

        [HttpDelete]
        [Route("deletePost/{postId}")]
        public async Task<IHttpActionResult> DeletePost(string postId)
        {
            bool deleted = await _storage.BlogManager.DeletePost(postId);
            if (deleted)
                return Ok(true);

            return NotFound();
        }
    }
}
