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
    public partial class DealServiceImpl : DealService
    {
        public string UpdateDeal(int id, string content, DateTime startTime, int duration)
        {
            string result = FAIL;
            Deal dl = new Deal( content, startTime, duration);
            dl.Id = id;
            try
            {
                if (dealRepository.UpdateDeal(dl))
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
        public string DeleteProductFromDeal(int proId, int dealId)
        {
            string result = FAIL;
            try
            {
                if (dealRepository.DeleteProductFromDeal(proId, dealId))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                //ex.LogExceptionToFile();
                throw new Exception(ex.Message);


            }
            return result;
        }
    }
}