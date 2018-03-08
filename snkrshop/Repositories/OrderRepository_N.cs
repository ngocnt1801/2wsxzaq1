using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface OrderRepository
    {
        bool DeleteOrder(int orderId);
        bool UpdateOrderStatus(int orderId, int orderStatus);
        User_Order GetOrder(int id, string username);
        int AddOrder(string username, float totalPrice );
    }
}