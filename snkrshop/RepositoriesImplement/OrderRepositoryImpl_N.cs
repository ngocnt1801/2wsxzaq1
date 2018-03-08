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
    public partial class OrderRepositoryImpl : OrderRepository
    {
        public bool UpdateOrderStatus(int orderId, int orderStatus)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "UpdateOrderStatus";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Status", orderStatus);
            cmd.Parameters.AddWithValue("@Id", orderId);

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

        public bool DeleteOrder(int orderId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeleteOrder";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Id", orderId);
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

        public User_Order GetOrder(int id, string username)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetDetailOfOrder";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@OrderId", id));
            cmd.Parameters.Add(new SqlParameter("@@Username", username));


            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new User_Order(  (int)reader["id"], 
                                            (DateTime)reader["date"], 
                                            (double)reader["totalPrice"], 
                                            (string)reader["userId"], 
                                            (int)reader["discount"], 
                                            (string)reader["voucherId"], 
                                            (bool)reader["type"], 
                                            (string)reader["statusName"]);
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

            return null;
        }

        public int AddOrder(string username, float totalPrice)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddOrder";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
            cmd.Parameters.AddWithValue("@UserId", username);
            SqlParameter param = cmd.Parameters.Add("@OrderId", SqlDbType.Int);
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

    }
}