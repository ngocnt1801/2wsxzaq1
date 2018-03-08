using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class User_Product_Item
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Discount { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public bool Type { get; set; }
        [DataMember]
        public double Price { get; set; }
        public string Tag { get; set; }
        public User_Product_Item(int productId, string name, double price, int discount, string url, bool type)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Discount = discount;
            Url = url;
            Type = type;

        }

        public User_Product_Item(int productId, string name, int discount, string url, bool type, double price, string tag)
        {
            ProductId = productId;
            Name = name;
            Discount = discount;
            Url = url;
            Type = type;
            Price = price;
            Tag = tag;
        }
    }
}