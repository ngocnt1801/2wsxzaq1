using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace snkrshop.RepositoriesImplement
{
    public partial class VoucherRepositoryImpl : VoucherRepository
    {
        public bool AddVoucher(Voucher theVoucher)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddVoucher";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Id", theVoucher.VoucherId);
            cmd.Parameters.AddWithValue("@type", theVoucher.Type);
            cmd.Parameters.AddWithValue("@discount", theVoucher.Discount);
            cmd.Parameters.AddWithValue("@description", theVoucher.Description);
            cmd.Parameters.AddWithValue("@startTime", theVoucher.StartTime);
            cmd.Parameters.AddWithValue("@duration", theVoucher.Duration);
            cmd.Parameters.AddWithValue("@amount", theVoucher.Amount);
            cmd.CommandType = CommandType.StoredProcedure;
            int result;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }

            }
            return result > 0;
        }
        public bool DeleteProductInVoucher(string voucherId, int productId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeleteProductVoucher";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@VoucherId", voucherId);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.CommandType = CommandType.StoredProcedure;
            int result;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }

            }
            return result > 0;
        }
    }
}