using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string  Content { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public int ParentID { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public string AuthorId { get; set; }

        public Comment(int id, string title, string content, DateTime time, int parentID, int productId, int postId, string authorId)
        {
            Id = id;
            Title = title;
            Content = content;
            Time = time;
            ParentID = parentID;
            ProductId = productId;
            PostId = postId;
            AuthorId = authorId;
        }

        public Comment(int id, string title, string content, DateTime time, int parentID, string authorId)
        {
            Id = id;
            Title = title;
            Content = content;
            Time = time;
            ParentID = parentID;
            AuthorId = authorId;
        }

        public Comment(int id, string title, string content, DateTime time, string authorId)
        {
            Id = id;
            Title = title;
            Content = content;
            Time = time;
            AuthorId = authorId;
        }
    }
}