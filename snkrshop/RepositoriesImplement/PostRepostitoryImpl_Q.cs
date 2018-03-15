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
        public List<Post> GetListPost(int sortTime)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetAllPost";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Post> result = new List<Post>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string url = "";
                    try
                    {
                        url = (string)reader["url"];
                    }
                    catch (Exception)
                    {

                        url = "";
                    }
                    result.Add(
                            new Post((int)reader["postId"],(string)reader["title"],(string)reader["postContent"], (DateTime)reader["timePost"],(string)reader["fullname"],url)
                        );
                }
                result = sortList(result, sortTime);
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
        public bool DeletePost(int postId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "DeletePost";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Id", postId);
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

        private List<Post> sortList(List<Post> list, int sort)
        {
            List<Post> sortedList = new List<Post>();
            if (sort >= 1)
            {
                sortedList = list.OrderBy(o => o.PostTime).ToList();
            }
            else if (sort <= -1)
            {
                sortedList = list.OrderByDescending(o => o.PostTime).ToList();
            }
            else
            {
                sortedList = list;
            }
            return sortedList;
        }
    }
}