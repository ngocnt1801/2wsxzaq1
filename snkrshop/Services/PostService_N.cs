using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Services
{
    partial interface PostService
    {
        string UpdatePost(int postId, string title, string content);
        string AddPost(int postId, string title, string content);
        Post GetPost(int id);
    }
}
