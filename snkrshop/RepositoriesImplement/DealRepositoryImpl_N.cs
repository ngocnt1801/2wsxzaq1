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
    public partial class DealRepositoryImpl : DealRepository
    {
        public int AddDeal(string content, DateTime startTime, int duration)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddDeal";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@DealContent", content);
            cmd.Parameters.AddWithValue("@StartTime", startTime);
            cmd.Parameters.AddWithValue("@Duration", duration);
            SqlParameter param = cmd.Parameters.Add("@DealId", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;

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
            return Convert.ToInt32(param.Value);
        }

        public bool DeleteDeal(int dealId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeleteDeal";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Id", dealId);
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

        public List<Deal> GetAllDeal()
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetAllDeal";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;


            List<Deal> deals = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (deals == null)
                    {
                        deals = new List<Deal>();
                    }
                    deals.Add(new Deal((int)reader["id"], (string)reader["dealContent"], (DateTime)reader["startTime"], (int)reader["duration"]));
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

            return deals;
        }
    }
}