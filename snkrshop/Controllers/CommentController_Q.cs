using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class CommentController : ApiController
    {
        [Route("comment/add")]
        [HttpPost]
        public string AddcommentToProduct(int proId, string username, string title, string content)
        {
            return commentService.AddcommentToProduct(proId, username, title, content);
        }
        [Route("comment/reply")]
        [HttpPost]
        public string ReplyComment(int parentId, string username, string content)
        {
            return commentService.ReplyComment( parentId, username, content);
        }
        [Route("comment/incomment")]
        [HttpGet]
        public IEnumerable<Comment> GetCommentInComment(int sortByTime, int parentId)
        {
            return commentService.GetCommentInComment(sortByTime, parentId);
        }
        [Route("comment/inpost")]
        [HttpGet]
        public List<Comment> GetCommentInPost(int sortByTime, int postId)
        {
            return commentService.GetCommentInPost(sortByTime, postId);
        }
        [Route("comment/inproduct")]
        [HttpGet]
        public List<Comment> GetCommentInProduct(int sortByTime, int ProductId)
        {
            
            return commentService.GetCommentInProduct(sortByTime, ProductId);
        }
    }
}