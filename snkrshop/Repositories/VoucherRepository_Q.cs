using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface VoucherRepository
    {
        bool AddVoucher(Voucher theVoucher);
        bool DeleteProductInVoucher(string voucherId, int productId);
    }
}
