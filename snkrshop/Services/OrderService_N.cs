using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Services
{
    partial interface OrderService
    {
        string DeleteOrder(int orderId);
        string CancelOrder(int orderId);
        string ApproveOrder(int orderId);
        User_Order GetDetailOfOrder(int orderId, string username);
        string Checkout(string userId, float totalPrice, ProductQuantity[] products, string voucher);
    }
}