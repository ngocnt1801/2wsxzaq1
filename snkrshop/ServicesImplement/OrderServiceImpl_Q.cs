using snkrshop.Models;
using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class OrderServiceImpl : OrderService 
    {
        public List<Order> GetOrderHistory(string userId)
        {
            List<Order> result = null;
            try
            {
                result = orderRepository.GetOrderHistory(userId);
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<Order> GetOrdersNotApproved()
        {
            List<Order> result = null;
            try
            {
                result = orderRepository.GetOrdersNotApproved();
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// get list all order
        /// </summary>
        /// <param name="sortByTime">1 to Ascending, 0 to no-sort, -1 to descending</param>
        /// <returns></returns>
        public List<Order> GetListOrder(int sortByTime)
        {
            List<Order> result = null;
            try
            {
                result = orderRepository.GetListOrder(sortByTime); 
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}