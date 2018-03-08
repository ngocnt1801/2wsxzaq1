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
    public partial class ProductRepositoryImpl : ProductRepository
    {
        public bool AddProduct(string name, string brand, float price, string country, string description, string material, int categoryId, int quantity,string tag)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddProduct";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Brand", brand);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Material", material);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Tag", tag);


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
        
        public User_Product GetProductDetail(int productId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetProductDetail";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProductId", productId));

            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    
                    string name = (string)reader["name"];
                    string brand = (string)reader["brand"];
                    double price = (double)reader["price"];
                    string country = (string)reader["country"];
                    string description = (string)reader["description"];
                    string material = (string)reader["material"];
                    int quantity = (int)reader["quantity"];
                    int discount = (int)reader["discount"];
                    bool type = (bool)reader["type"];
                    DateTime startTime = (DateTime)reader["startTime"];
                    int duration = (int)reader["duration"];

                    return new User_Product(productId,name,brand,price,country,description,material, quantity,discount,type,startTime,duration);
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
        
        public bool UpdateProduct(int id, string name, string brand, float price, string country, string description, string material, int categoryId, int quantity, string tag)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "UpdateProduct";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Brand", brand);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Material", material);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Tag", tag);


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

        public List<User_Product_Item> GetProductsSortByDiscount()
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetProductsSortByDiscount";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            List<User_Product_Item> products = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (products == null)
                    {
                        products = new List<User_Product_Item>();
                    }
                    products.Add(new User_Product_Item((int)reader["productId"],
                                                        (string)reader["name"],
                                                        (double)reader["price"],
                                                        (int)reader["discount"],
                                                        (string)reader["url"],
                                                        (bool)reader["type"]));
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

            return products;
        }

    }
}