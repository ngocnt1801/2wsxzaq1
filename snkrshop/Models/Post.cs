using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public DateTime PostTime { get; set; }
        [DataMember]
        public string UserId { get; set; }

        public Post(int id, string title, string content, DateTime postTime, string userId)
        {
            Id = id;
            Title = title;
            Content = content;
            PostTime = postTime;
            UserId = userId;
        }
    }
}