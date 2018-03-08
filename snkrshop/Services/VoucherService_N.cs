using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Services
{
    partial interface VoucherService
    {
        string DeleteVoucher(int voucherId);
        string AddVoucherProduct(string voucherId, int productId);
        List<Voucher> GetAllVoucher();
    }
}