using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class User_ProductSize
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int SizeId { get; set; }
        [DataMember]
        public string SizeName { get; set; }

        public User_ProductSize()
        {
        }

        public User_ProductSize(int productId, int sizeId, string sizeName)
        {
            ProductId = productId;
            SizeId = sizeId;
            SizeName = sizeName;
        }
    }
}