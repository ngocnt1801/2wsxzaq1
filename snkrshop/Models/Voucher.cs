using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{
    [DataContract]
    public class Voucher
    {
        [DataMember]
        public string VoucherId { get; set; }
        [DataMember]
        public bool Type { get; set; }
        [DataMember]
        public int Discount { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public int Amount { get; set; }

        public Voucher(string voucherId, bool type, int discount, string description, DateTime startTime, int duration, int amount)
        {
            VoucherId = voucherId;
            Type = type;
            Discount = discount;
            Description = description;
            StartTime = startTime;
            Duration = duration;
            Amount = amount;
        }
    }
}