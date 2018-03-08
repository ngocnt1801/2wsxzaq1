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
    public partial class OrderProductRepositoryImpl : OrderProductRepository
    {
        public bool AddProductOrder(int orderId, int productId, int quantity)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddOrderProduct";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);

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

        public List<User_ProductOrder> GetListProductOfOrder(int orderId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetListProductInOrder";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@OderId", orderId));

            List<User_ProductOrder> users = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (users == null)
                    {
                        users = new List<User_ProductOrder>();
                    }
                    users.Add(new User_ProductOrder((int)reader["productId"],
                                                    (string)reader["name"],
                                                    (int)reader["quantity"],
                                                    (string)reader["brand"],
                                                    (float)reader["price"],
                                                    (string)reader["size"],
                                                    (string)reader["country"],
                                                    (string)reader["material"],
                                                    (string)reader["color"] ));
                                                    
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

            return users;
        }
    }
}