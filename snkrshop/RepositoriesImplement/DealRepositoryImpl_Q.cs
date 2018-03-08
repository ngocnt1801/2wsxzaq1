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
        public bool UpdateDeal(Deal Edited)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "UpdateDealInformation";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@DealId", Edited.Id);
            cmd.Parameters.AddWithValue("@Content", Edited.Content);
            cmd.Parameters.AddWithValue("@StartTime", Edited.StartTime);
            cmd.Parameters.AddWithValue("@Duration", Edited.Duration);
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
        public bool DeleteProductFromDeal(int proId, int dealId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeleteProductDeal";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Id", dealId);
            cmd.Parameters.AddWithValue("@ProductId", proId);
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