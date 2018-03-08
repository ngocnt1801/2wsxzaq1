using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Services
{
    partial interface CommentService
    {
        string AddcommentToProduct(int proId, string username, string title, string content);
        string ReplyComment(int parentId, string username, string content);
        List<Comment> GetCommentInComment(int sortByTime, int parentId);
        List<Comment> GetCommentInPost(int sortByTime, int postId);
        List<Comment> GetCommentInProduct(int sortByTime, int ProductId);
        string EditComment(int commentId, string title, string content);
    }
}