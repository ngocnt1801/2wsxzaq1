using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface OrderVoucherRepository
    {
        bool AddOrderVoucher(int orderId, string voucherId);
    }
}
