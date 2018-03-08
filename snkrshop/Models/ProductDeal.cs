using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class ProductDeal
    {
        [DataMember]
        public int DealId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Discount { get; set; }
        [DataMember]
        public bool Type { get; set; }
    }
}