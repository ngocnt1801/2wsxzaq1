using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class VoucherController : ApiController
    {
        [Route("voucher/add")]
        [HttpPost]
        string AddVoucher(string voucherId, bool type, int discount, string description, DateTime startTime, int duration, int amount)
        {
            return this.voucherService.AddVoucher( voucherId, type, discount, description, startTime, duration, amount);
        }
        [Route("voucher/delete/product")]
        [HttpGet]
        string DeleteProductInVoucher(string voucherId, int productId)
        {
            return this.voucherService.DeleteProductInVoucher(voucherId, productId);
        }
    }
}