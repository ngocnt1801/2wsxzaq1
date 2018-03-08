using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Services
{
    partial interface OrderService
    {
        List<Order> GetOrderHistory(string userId);
        List<Order> GetOrdersNotApproved();

        /// <summary>
        /// get list all order
        /// </summary>
        /// <param name="sortByTime">1 to Ascending, 0 to no-sort, -1 to descending</param>
        /// <returns></returns>
        List<Order> GetListOrder(int sortByTime);
    }
}
