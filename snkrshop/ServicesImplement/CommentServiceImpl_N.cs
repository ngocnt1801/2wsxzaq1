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
        const string FAIL = "fail";
        const string SUCCESS = "success";
        CommentRepository commentRepository;

        public CommentServiceImpl()
        {
            commentRepository = new CommentRepositoryImpl();
        }

        public string AddCommentToPost(string title, string content, int postId, string authorId)
        {
            string result = FAIL;
            try
            {
                if (commentRepository.AddCommentToPost(title, content, postId, authorId))
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

        public string DeleteComment(int commentId)
        {
            string result = FAIL;
            try
            {
                if(commentRepository.DeleteComment(commentId))
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
    }
}