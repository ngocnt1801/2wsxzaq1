using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Services
{
    partial interface DealService
    {
        string UpdateDeal(int id, string content, DateTime startTime, int duration);
        string DeleteProductFromDeal(int proId, int dealId);
    }
}
