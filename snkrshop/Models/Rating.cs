using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Rating
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public int Rate { get; set; }
    }
}