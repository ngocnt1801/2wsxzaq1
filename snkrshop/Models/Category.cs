using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ParentId { get; set; }

        public Category(string name, string description, int parentId)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}