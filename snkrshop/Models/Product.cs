using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Product
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
        public string Country { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Material { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Tag { get; set; }
        [DataMember]
        public DateTime LastModified { get; set; }
        [DataMember]
        public int CategoryId { get; set; }

        public Product(int productId, string name, string brand, double price, string country, string description, string material, string category, int quantity, string tag, DateTime lastModified, int categoryId)
        {
            ProductId = productId;
            Name = name;
            Brand = brand;
            Price = price;
            Country = country;
            Description = description;
            Material = material;
            Category = category;
            Quantity = quantity;
            Tag = tag;
            LastModified = lastModified;
            CategoryId = categoryId;
        }
    }
}