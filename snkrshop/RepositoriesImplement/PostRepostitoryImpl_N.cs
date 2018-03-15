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
    public partial class PostRepostitoryImpl : PostRepository
    {
        public bool AddPost(int postId, string title, string content)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddPost";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Content", content);
            cmd.Parameters.AddWithValue("@PostId", postId);


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

        

        public Post GetPost(int id)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetPostById";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",id);

            
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string url = null;
                    try
                    {
                        url = (string)reader["url"];
                    }
                    catch (Exception)
                    {
                        url = "";
                        //log file
                    }
                    
                    return new Post((int)reader["postId"], (string)reader["title"], (string)reader["postContent"], (DateTime)reader["timePost"], (string)reader["fullname"],url);
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

        public bool UpdatePost(int postId, string title, string content)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "UpdatePost";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Content", content);
            cmd.Parameters.AddWithValue("@PostId", postId);


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