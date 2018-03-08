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
        public bool DeleteVoucher(int voucherId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeleteVoucher";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@VoucherId", voucherId);
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

        public List<Voucher> GetAllVoucher()
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetAllVoucher";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;


            List<Voucher> vouchers = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (vouchers == null)
                    {
                        vouchers = new List<Voucher>();
                    }
                    vouchers.Add(new Voucher((string)reader["voucherId"], (bool)reader["type"],(int)reader["discount"],(string)reader["description"],(DateTime)reader["startTime"],(int)reader["duration"],(int)reader["quantity"]));
                }

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

            return vouchers;
        }
    }
}