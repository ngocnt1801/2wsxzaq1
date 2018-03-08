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
        List<Post> GetListPost(int sortTime);
        string DeletePost(int postId);
    }
}
