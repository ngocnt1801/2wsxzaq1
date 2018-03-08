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
    public partial class CommentRepositoryImpl : CommentRepository
    {
        public bool AddcommentToProduct(int proId, string username, string title, string content)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddCommentOFProduct";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Content", content);
            cmd.Parameters.AddWithValue("@ProductId", proId);
            cmd.Parameters.AddWithValue("@AuthorId", username);
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

        public bool EditComment(int commentId, string title, string content)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "UpdateComment";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CoId", commentId);
            cmd.Parameters.AddWithValue("@Content", content);
            cmd.Parameters.AddWithValue("@Title", title);
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
        
        public List<Comment> GetCommentInComment(int sortByTime, int parentId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetCommentOfComment";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CoId", parentId);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Comment> result = new List<Comment>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Comment((int)reader["id"], (string)reader["title"], (string)reader["commentContent"], (DateTime)reader["time"], (int)reader["parentId"], (string)reader["authorId"])
                        );
                }
                result=sortList(result, sortByTime);
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

        public List<Comment> GetCommentInPost(int sortByTime, int postId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetPostComment";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@PostId", postId);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Comment> result = new List<Comment>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string title = (string)reader["title"];
                    string content = (string)reader["commentContent"];
                    DateTime time = (DateTime)reader["time"];
                    string authorId = (string)reader["authorId"];
                    result.Add(
                        new Comment(id, title, content, time, authorId)
                        );
                }
                result = sortList(result, sortByTime);
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

        public List<Comment> GetCommentInProduct(int sortByTime, int productId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetProductComment";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Comment> result = new List<Comment>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string title = (string)reader["title"];
                    string content = (string)reader["commentContent"];
                    DateTime time = (DateTime)reader["time"];
                    string authorId = (string)reader["authorId"];
                    result.Add(
                        new Comment(id, title, content, time, authorId)
                        );
                }
                result = sortList(result, sortByTime);
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

        public bool ReplyComment(int parentId, string username, string content)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "ReplyComment";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Content", content);
            cmd.Parameters.AddWithValue("@ParentId", parentId);
            cmd.Parameters.AddWithValue("@AuthorId", username);
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
        
        private List<Comment> sortList(List<Comment> list,int sort)
        {
            List<Comment> sortedList = new List<Comment>();
            if (sort >= 1)
            {
                sortedList = list.OrderBy(o => o.Time).ToList();
            }else if(sort <= -1)
            {
                sortedList = list.OrderByDescending(o => o.Time).ToList();
            }
            else
            {
                sortedList = list;
            }
            return sortedList;
        }
    }
}