using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface DealRepository
    {
        bool UpdateDeal(Deal Edited);
        bool DeleteProductFromDeal(int proId, int dealId);

    }
}
