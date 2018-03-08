using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface OrderProductRepository
    {
        List<User_ProductOrder> GetListProductOfOrder(int orderId);
        bool AddProductOrder(int orderId, int productId, int quantity);
    }
}