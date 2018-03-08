using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface CommentRepository
    {
        bool DeleteComment(int commentId);
        bool AddCommentToPost(string title, string content, int postId, string authorId);
    }
}