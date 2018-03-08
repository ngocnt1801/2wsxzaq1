using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface VoucherProductRepository
    {
        bool AddVoucherProduct(string voucherId, int productId);
    }
}
