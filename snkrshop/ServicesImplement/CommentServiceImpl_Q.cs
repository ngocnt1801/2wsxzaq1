using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.RepositoriesImplement;
using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class CommentServiceImpl : CommentService
    {
        public string AddcommentToProduct(int proId, string username, string title, string content)
        {
            string result = FAIL;
            try
            {
                if (commentRepository.AddcommentToProduct( proId,  username, title, content))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public string ReplyComment(int parentId, string username, string content)
        {
            string result = FAIL;
            try
            {
                if (commentRepository.ReplyComment(parentId, username, content))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<Comment> GetCommentInComment(int sortByTime, int parentId)
        {
            List<Comment> result = null;
            try
            {
                result = commentRepository.GetCommentInComment(sortByTime, parentId);
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<Comment> GetCommentInPost(int sortByTime, int postId)
        {
            List<Comment> result = null;
            try
            {
                result = commentRepository.GetCommentInPost(sortByTime, postId);
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<Comment> GetCommentInProduct(int sortByTime, int productId)
        {
            List<Comment> result = null;
            try
            {
                result = commentRepository.GetCommentInProduct(sortByTime, productId);
            }
            catch (Exception ex)
            {
                //ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public string EditComment(int commentId, string title, string content)
        {
            string result = FAIL;
            try
            {
                if (commentRepository.EditComment(commentId, title, content))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                //ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}