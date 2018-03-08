using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class VoucherProduct
    {
        [DataMember]
        public string VoucherId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
    }
}