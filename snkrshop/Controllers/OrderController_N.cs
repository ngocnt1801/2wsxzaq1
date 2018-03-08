using snkrshop.Models;
using snkrshop.Services;
using snkrshop.ServicesImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class OrderController:ApiController
    {
        OrderService orderService = new OrderServiceImpl();

        [Route("order/delete")]
        [HttpGet]
        public string DeleteOrder(int orderId)
        {
            return this.orderService.DeleteOrder(orderId);
        }
        [Route("order/cancel")]
        [HttpGet]
        public string CancelOrder(int orderId)
        {
            return this.orderService.CancelOrder(orderId);
        }
        [Route("order/approve")]
        [HttpGet]
        public string ApproveOrder(int orderId)
        {
            return this.orderService.ApproveOrder(orderId);
        }
        [Route("order/{username}/{orderId}")]
        [HttpGet]
        public User_Order GetOrder(string username, int orderId)
        {
            return this.orderService.GetDetailOfOrder(orderId, username);
        }

        [Route("order/{username}/checkout")]
        [HttpPost]
        public String Checkout(string username, float totalPrice, ProductQuantity[] products, string voucher)
        {
            return this.orderService.Checkout(username, totalPrice, products, voucher);
        }

    }
}