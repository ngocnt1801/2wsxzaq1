using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Models
{
    public class User_Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime timePost { get; set; }
        public string Author { get; set; }

        public User_Post()
        {
        }

        public User_Post(int postId, string title, DateTime timePost, string author)
        {
            PostId = postId;
            Title = title;
            this.timePost = timePost;
            Author = author;
        }
    }
}