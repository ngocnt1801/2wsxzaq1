﻿using snkrshop.Models;
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
                    int discount = 0;
                    try
                    {
                        discount = (int)reader["discount"];
                    }
                    catch (Exception)
                    {
                        //log file
                    }
                    bool type = true;
                    try
                    {
                        type = (bool)reader["type"];
                    }
                    catch (Exception)
                    {
                        //log file
                    }

                    DateTime? startTime = null;
                    try
                    {
                      startTime  = (DateTime)reader["startTime"];
                    }
                    catch (Exception)
                    {
                        //log file
                    }
                    int duration = 0;
                    try
                    {
                        duration = (int)reader["duration"];
                    }
                    catch (Exception)
                    {
                        //log file
                    }
                    if (startTime == null)
                    {
                        return new User_Product(productId, price, name, brand, country, description, material, quantity, discount, type, duration);
                    }else
                    {
                        return new User_Product(productId, price,(DateTime)startTime, name, brand, country, description, material, quantity, discount, type, duration);

                    }
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

        public List<Product> GetAllProduct()
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetAllProductForAdmin";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            List<Product> products = null;
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
                        products = new List<Product>();
                    }
                    products.Add(new Product((int)reader["productId"],
                                                        (string)reader["name"],
                                                        (string)reader["brand"],
                                                        (double)reader["price"],
                                                        (string)reader["country"],
                                                        (string)reader["description"],
                                                        (string)reader["material"],
                                                        (string)reader["categoryName"],
                                                        (int)reader["quantity"],
                                                        (string)reader["tag"],
                                                        (DateTime)reader["lastModified"],
                                                        (int)reader["categoryId"]));

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

        public Admin_Product GetProductDetailForAdmin(int productId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetProductDetailForAdmin";
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
                    string categoryName = (string)reader["categoryName"];
                    int categoryId = (int)reader["categoryID"];
                    int quantity = (int)reader["quantity"];
                    string tag = (string)reader["tag"];
                    DateTime modified = (DateTime)reader["lastModified"];
              

                    return new Admin_Product(productId,name,brand,price,country,description,material,categoryName,quantity,tag,modified,categoryId);
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
    }
}