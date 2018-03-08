using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface VoucherRepository
    {
        bool DeleteVoucher(int voucherId);
        List<Voucher> GetAllVoucher();
    }
}