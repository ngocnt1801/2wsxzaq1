using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class VoucherServiceImpl : VoucherService
    {
        public string AddVoucher(string voucherId, bool type, int discount, string description, DateTime startTime, int duration, int amount)
        {
            string result = FAIL;
            try
            {
                if (voucherRepository.AddVoucher(
                        new Models.Voucher( voucherId, type, discount, description, startTime, duration, amount)
                    ))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public string DeleteProductInVoucher(string voucherId, int productId)
        {
            string result = FAIL;
            try
            {
                if (voucherRepository.DeleteProductInVoucher(voucherId, productId))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}