using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Admin_Product : Product
    {
        public Admin_Product(int productId, string name, string brand, double price, string country, string description, string material, string category, int quantity, string tag, DateTime lastModified, int categoryId) : base(productId, name, brand, price, country, description, material, category, quantity, tag, lastModified, categoryId)
        {
        }

        [DataMember]
        public List<Size> Sizes { get; set; }
        [DataMember]
        public List<Color> Colors { get; set; }
        [DataMember]
        public List<Image> Images { get; set; }

        
    }
}