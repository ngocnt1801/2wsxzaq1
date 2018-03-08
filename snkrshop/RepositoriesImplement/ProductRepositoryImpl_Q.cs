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
        public List<User_Product_Item> GetListProduct( int sortByPrice, int sortById)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetAllProductForUser";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<User_Product_Item> result = new List<User_Product_Item>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int productId = (int)reader["productId"];
                    string name = (string)reader["name"];
                    
                    double price = 0;
                    try
                    {
                        price = (double)reader["price"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    
                    int discount = 0;
                    try
                    {
                        discount = (int)reader["discount"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    string url = "";
                    try
                    {
                        url = (string)reader["url"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    bool type = false;
                    try
                    {
                        type = (bool)reader["type"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    string tag = name;
                    try
                    {
                        tag = (string)reader["tag"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    result.Add(
                            new User_Product_Item(productId, name, discount, url, type, price, tag)
                            );
                }
                result = sortList(result, sortByPrice, sortById);

                
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
            return result;
        }

        public IEnumerable<User_Product_Item> SearchProduct(string searchString)
        {
            IEnumerable<User_Product_Item> products = this.GetListProduct(0,0);
            string[] tags = searchString.Split(' ');
            foreach (string tag in tags)
            {
                products = from product in products
                           where product.Tag.Contains(tag)
                           select product;
            }
            return products;
        }

        //public List<User_Product_Item> GetSearchProduct(string searchString)
        //{
            
        //    SqlConnection cnn = DBUtils.GetConnection();
        //    string sql = "SearchProductByName";
        //    SqlCommand cmd = new SqlCommand(sql, cnn);
        //    cmd.Parameters.AddWithValue("@SearchValue", "%"+searchString+"%");
            
            
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    List<User_Product_Item> result = new List<User_Product_Item>();
        //    try
        //    {
        //        if (cnn.State == ConnectionState.Closed)
        //        {
        //            cnn.Open();
        //        }
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //     //       string search = (string)reader["value"];
        //            result.Add(
        //                    new User_Product_Item((int)reader["productId"],
        //                                                (string)reader["name"],
        //                                                (double)reader["price"],
        //                                                (int)reader["discount"],
        //                                                (string)reader["url"],
        //                                                (bool)reader["type"])
        //                );
        //        }
        //        //result = sortList(result, sortByPrice, sortById);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (cnn.State == ConnectionState.Open)
        //        {
        //            cnn.Close();
        //        }
        //    }
        //    return result;
            
        //}
        public bool RatingProduct(int productId, string userId, int rate)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "RatingProduct";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Rate", rate);
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
        public List<User_Product_Item> GetProductByCategory(int categoryId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "ProductListByCategory";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.CommandType = CommandType.StoredProcedure;
            List<User_Product_Item> result = new List<User_Product_Item>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int productId = (int)reader["productId"];
                    string name = (string)reader["name"];

                    double price = 0;
                    try
                    {
                        price = (double)reader["price"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    int discount = 0;
                    try
                    {
                        discount = (int)reader["discount"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    string url = "";
                    try
                    {
                        url = (string)reader["url"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    bool type = false;
                    try
                    {
                        type = (bool)reader["type"];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    result.Add(
                            new User_Product_Item(productId, name, price, discount, url, type)
                            );
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
            return result;
        }
        public bool DeleteProduct(int productId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeleteProduct";
            SqlCommand cmd = new SqlCommand(sql, cnn);
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
        public bool AddProductColor(int productId, string color)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddProductColor";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Color", color);
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

        private List<User_Product_Item> sortList(List<User_Product_Item> list, int sortByPrice, int sortById)
        {
            List<User_Product_Item> sortedList = new List<User_Product_Item>();
            //sort by Id
            if (sortById >= 1)
            {
                sortedList = list.OrderBy(o => o.ProductId).ToList();
            }
            else if (sortById <= -1)
            {
                sortedList = list.OrderByDescending(o => o.ProductId).ToList();
            }
            else
            {
                sortedList = list;
            }
            //sort by price
            if (sortByPrice >= 1)
            {
                sortedList = list.OrderBy(o => o.Price).ToList();
            }
            else if (sortByPrice <= -1)
            {
                sortedList = list.OrderByDescending(o => o.Price).ToList();
            }
            else
            {
                sortedList = list;
            }
            //sort by Discount - not ready
            //if (sortByDiscount >= 1)
            //{
            //    sortedList = list.OrderBy(o => o.dis).ToList();
            //}
            //else if (sortByDiscount <= -1)
            //{
            //    sortedList = list.OrderByDescending(o => o.Price).ToList();
            //}
            //else
            //{
            //    sortedList = list;
            //}

            return sortedList;
        }
    }
}