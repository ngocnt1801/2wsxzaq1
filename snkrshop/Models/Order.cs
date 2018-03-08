using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public double TotalPrice { get; set; }
        [DataMember]
        public int OrderStatus { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public int GuestId { get; set; }
        [DataMember]
        public string ApprovederId { get; set; }

        public Order(int orderId, DateTime orderDate, double totalPrice, int orderStatus, string userId, int guestId, string approvederId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = orderStatus;
            UserId = userId;
            GuestId = guestId;
            ApprovederId = approvederId;
        }
    }
}
