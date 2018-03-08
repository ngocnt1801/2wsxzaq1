using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Services
{
    partial interface DealService
    {
        string DeleteDeal(int dealId);
        int AddDeal(string content, DateTime startTime, int duration);
        string AddProductDeal(int dealId, int productId, int discount, bool type);
        string UpdateProductDeal(int dealId, int productId, int discount, bool type);
        List<Deal> GetAllDeal();
    }
}