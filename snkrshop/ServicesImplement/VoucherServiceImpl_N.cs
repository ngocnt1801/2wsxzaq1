using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.RepositoriesImplement;
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
        const string FAIL = "fail";
        const string SUCCESS = "success";

        VoucherRepository voucherRepository;
        VoucherProductRepository voucherProductRepository;

        public VoucherServiceImpl()
        {
            this.voucherRepository = new VoucherRepositoryImpl();
            this.voucherProductRepository = new VoucherProductRepositoryImpl();
        }

        public string AddVoucherProduct(string voucherId, int productId)
        {
            string result = FAIL;
            try
            {
                if (voucherProductRepository.AddVoucherProduct(voucherId, productId))
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

        public string DeleteVoucher(int voucherId)
        {
            string result = FAIL;
            try
            {
                if (voucherRepository.DeleteVoucher(voucherId))
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

        public List<Voucher> GetAllVoucher()
        {
            try
            {
                return this.voucherRepository.GetAllVoucher();
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
        }
    }
}