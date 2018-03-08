using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class User_ProductColor
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int ColorId { get; set; }
        [DataMember]
        public string ColorName { get; set; }

        public User_ProductColor()
        {
        }

        public User_ProductColor(int productId, int colorId, string colorName)
        {
            ProductId = productId;
            ColorId = colorId;
            ColorName = colorName;
        }
    }
}