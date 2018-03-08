using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class OrderVoucher
    {
        [DataMember]
        public string VoucherId { get; set; }
        [DataMember]
        public int OrderId { get; set; }
    }
}