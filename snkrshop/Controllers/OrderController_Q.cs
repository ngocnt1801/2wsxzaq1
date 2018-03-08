using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class OrderController : ApiController
    {
        [Route("order/history")]
        [HttpGet]
        public List<Order> GetOrderHistory(string userId)
        {
            return this.orderService.GetOrderHistory(userId);
        }
        [Route("order/notapproved")]
        [HttpGet]
        public List<Order> GetOrdersNotApproved()
        {
            return this.orderService.GetOrdersNotApproved();
        }
        [Route("order/all")]
        [HttpGet]
        public List<Order> GetListOrder(int sortByTime)
        {
            return this.orderService.GetListOrder(sortByTime);
        }

    }
}