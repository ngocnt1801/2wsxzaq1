using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface ProductDealRepository
    {
        bool AddProductDeal(int dealId, int productId, int discount, bool type);
        bool UpdateProductDeal(int dealId, int productId, int discount, bool type);
    }
}
