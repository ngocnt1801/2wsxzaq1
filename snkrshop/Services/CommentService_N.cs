using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Services
{
    partial interface CommentService
    {
        string DeleteComment(int commentId);
        string AddCommentToPost(string title, string content, int postId, string authorId);
    }
}