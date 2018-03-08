using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Services
{
    partial interface VoucherService
    {
        string AddVoucher(string voucherId, bool type, int discount, string description, DateTime startTime, int duration, int amount);
        string DeleteProductInVoucher(string voucherId, int productId);
    }
}
