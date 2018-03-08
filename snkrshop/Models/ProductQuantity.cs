using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class ProductQuantity
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public ProductQuantity()
        {
        }

        public ProductQuantity(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}