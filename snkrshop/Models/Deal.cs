using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Deal
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public int Duration { get; set; }

        public Deal( string content, DateTime startTime, int duration)
        {
            Content = content;
            StartTime = startTime;
            Duration = duration;
        }

        public Deal(int id, string content, DateTime startTime, int duration)
        {
            Id = id;
            Content = content;
            StartTime = startTime;
            Duration = duration;
        }
    }
}