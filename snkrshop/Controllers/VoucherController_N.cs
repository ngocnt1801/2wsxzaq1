using snkrshop.Models;
using snkrshop.Services;
using snkrshop.ServicesImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class VoucherController : ApiController
    {
        VoucherService voucherService = new VoucherServiceImpl();

        [Route("voucher/delete")]
        [HttpGet]
        public string DeleteVoucher(int voucherId)
        {
            return this.voucherService.DeleteVoucher(voucherId);
        }

        [Route("voucher/product/add")]
        [HttpPost]
        public string AddVoucherProduct(string voucherId, int productId)
        {
            return this.voucherService.AddVoucherProduct(voucherId, productId);
        }

        [Route("voucher/all")]
        [HttpGet]
        public List<Voucher> GetAllVoucher()
        {
            return this.voucherService.GetAllVoucher();
        }
    }
}
