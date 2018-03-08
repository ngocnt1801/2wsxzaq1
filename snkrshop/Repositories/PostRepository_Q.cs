using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface PostRepository
    {
        /// <summary>
        /// get list of post and sort it
        /// </summary>
        /// <param name="sortTime">1 to Ascending, 0 to no-sort, -1 to descending</param>
        /// <returns></returns>
        List<Post> GetListPost(int sortTime);
        bool DeletePost(int postId);

    }
}
