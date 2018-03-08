using snkrshop.Models;
using snkrshop.Services;
using snkrshop.ServicesImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class PostController : ApiController
    {
        CommentService commentService = new CommentServiceImpl();
        PostService postService = new PostServiceImpl();

        [Route("post/comment/add")]
        [HttpPost]
        public string AddCommentInPost(string title, string content, int postId, string authorId)
        {
            return commentService.AddCommentToPost(title, content, postId, authorId);
        }

        [Route("post/update")]
        [HttpPost]
        public string UpdatePost(int postId, string title, string content)
        {
            return this.postService.UpdatePost(postId, title, content);
        }

        [Route("post/add")]
        [HttpPost]
        public string AddPost(int postId, string title, string content)
        {
            return this.postService.AddPost(postId, title, content);
        }

        [Route("post/{id}")]
        [HttpGet]
        public Post GetPost(int id)
        {
            return this.postService.GetPost(id);
        }
    }
}
