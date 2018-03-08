using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class User_Order
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public double TotalPrice { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public int Discount { get; set; }
        [DataMember]
        public string VoucherId { get; set; }
        [DataMember]
        public bool Type { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public List<User_ProductOrder> Products { get; set; }

        public User_Order(int orderId, DateTime orderDate, double totalPrice, string userId, int discount, string voucherId, bool type, string statusName)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            UserId = userId;
            Discount = discount;
            VoucherId = voucherId;
            Type = type;
            StatusName = statusName;
        }

        
    }
}