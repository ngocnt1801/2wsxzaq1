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
    public partial class CategoryRepositoryImpl : CategoryRepository
    {
        public bool AddCategory(Category theNewCategory)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddCategory";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", theNewCategory.Name);
            cmd.Parameters.AddWithValue("@Description", theNewCategory.Description);
            cmd.Parameters.AddWithValue("@ParentId", theNewCategory.ParentId);
            cmd.CommandType = CommandType.StoredProcedure;
            int result;
            try
            {
                if(cnn.State == ConnectionState.Closed)
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
        public bool UpdateCategory(Category theEdited)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "UpdateCategory";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Id", theEdited.Id);
            cmd.Parameters.AddWithValue("@Name", theEdited.Name);
            cmd.Parameters.AddWithValue("@Description", theEdited.Description);
            cmd.Parameters.AddWithValue("@ParentId", theEdited.ParentId);
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