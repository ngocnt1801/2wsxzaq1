using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace snkrshop.RepositoriesImplement
{
    public partial class CategoryRepositoryImpl : CategoryRepository
    {
        public bool DeleteCategory(int categoryId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeleteCategory";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
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

        public List<Category> GetAllCategory()
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetAllCategory";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            

            List<Category> categories = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (categories == null)
                    {
                        categories = new List<Category>();
                    }
                    categories.Add(new Category((int)reader["id"],(string)reader["name"]));
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

            return categories;
        }
    }
}