using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Image
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public string Url { get; set; }

        public Image(int id, string url)
        {
            Id = id;
            Url = url;
        }
    }
}