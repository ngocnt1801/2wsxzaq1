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
    public partial class CommentController : ApiController
    {
        CommentService commentService = new CommentServiceImpl();

        [Route("comment/delete")]
        [HttpGet]
        public string DeleteComment(int commentId)
        {
            return commentService.DeleteComment(commentId);
        }

        
        
    }
}
