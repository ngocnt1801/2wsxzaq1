using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class User_ProductOrder
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public string Size { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Material { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }

        public User_ProductOrder(int productId, string productName, int quantity, string brand, float price, string size, string country, string material, string color)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Brand = brand;
            Price = price;
            Size = size;
            Country = country;
            Material = material;
            Color = color;
        }
    }
}