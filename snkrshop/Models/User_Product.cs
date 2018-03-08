using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class User_Product
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public List<Size> Sizes { get; set; }
        [DataMember]
        public List<Color> Colors { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Material { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int Discount { get; set; }
        [DataMember]
        public bool Type { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public List<Image> Images { get; set; }

        public User_Product(int productId, string name, string brand, double price, string country, string description, string material, int quantity, int discount, bool type, DateTime startTime, int duration)
        {
            ProductId = productId;
            Name = name;
            Brand = brand;
            Price = price;
            Country = country;
            Description = description;
            Material = material;
            Quantity = quantity;
            Discount = discount;
            Type = type;
            StartTime = startTime;
            Duration = duration;
        }
    }
}