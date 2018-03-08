using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Models
{
    public class OrderStatus
    {
        public static readonly int STATUS_NOT_APPROVE = 1;
        public static readonly int STATUS_APPROVED = 2;
        public static readonly int STATUS_SHIPPING = 3;
        public static readonly int STATUS_RECEIVED = 4;
        public static readonly int STATUS_CANCEL = 5;
    }
}