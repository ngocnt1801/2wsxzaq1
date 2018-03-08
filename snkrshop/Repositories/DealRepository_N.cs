using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface DealRepository
    {
        bool DeleteDeal(int dealId);
        int AddDeal(string content, DateTime startTime, int duration);
        List<Deal> GetAllDeal();
    }
}