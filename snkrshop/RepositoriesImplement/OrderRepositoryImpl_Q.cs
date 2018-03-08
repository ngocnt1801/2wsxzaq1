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
        public List<Order> GetOrderHistory(string userId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetCommentOfComment";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CoId", userId);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Order> result = new List<Order>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //string custommer = (string)reader["userId"];
                    //if(custommer.Length <=0)
                    //{
                    //    custommer = ""+(int)reader["guestId"];
                    //}
                    result.Add(
                            new Order((int)reader["id"], (DateTime)reader["date"], (double)reader["totalPrice"], (int)reader["status"], (string)reader["userId"], (int)reader["guestId"], (string)reader["approveder_id"])
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
        public List<Order> GetOrdersNotApproved()
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "View_OrderNotApproved";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Order> result = new List<Order>();
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
                            new Order((int)reader["id"], (DateTime)reader["date"], (double)reader["totalPrice"], (int)reader["status"], (string)reader["userId"], (int)reader["guestId"], (string)reader["approveder_id"])
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

        /// <summary>
        /// get list all order
        /// </summary>
        /// <param name="sortByTime">1 to Ascending, 0 to no-sort, -1 to descending</param>
        /// <returns></returns>
        public List<Order> GetListOrder(int sortByTime)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "View_AllOrder";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Order> result = new List<Order>();
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
                            new Order((int)reader["id"], (DateTime)reader["date"], (double)reader["totalPrice"], (int)reader["status"], (string)reader["userId"], (int)reader["guestId"], (string)reader["approveder_id"])
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
        private List<Order> sortList(List<Order> list, int sort)
        {
            List<Order> sortedList = new List<Order>();
            if (sort >= 1)
            {
                sortedList = list.OrderBy(o => o.OrderDate).ToList();
            }
            else if (sort <= -1)
            {
                sortedList = list.OrderByDescending(o => o.OrderDate).ToList();
            }
            else
            {
                sortedList = list;
            }
            return sortedList;
        }
    }
}