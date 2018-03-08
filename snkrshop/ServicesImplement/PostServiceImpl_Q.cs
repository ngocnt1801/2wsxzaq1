using snkrshop.Models;
using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class PostServiceImpl : PostService
    {
        public List<Post> GetListPost(int sortTime)
        {
            List<Post> result = null;
            try
            {
                result = postRepository.GetListPost(sortTime);
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public string DeletePost(int postId)
        {
            string result = FAIL;
            try
            {
                if (postRepository.DeletePost(postId))
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