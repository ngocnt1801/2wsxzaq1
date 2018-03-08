using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace snkrshop.RepositoriesImplement
{
    public partial class UserRepositoryImpl : UserRepository
    {
        public bool AddUser(string username, string password, string fullname, string email, string phone, string address)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "AddUser";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Username",username));
            cmd.Parameters.Add(new SqlParameter("@Password",password));
            cmd.Parameters.Add(new SqlParameter("@Fullname",fullname));
            cmd.Parameters.Add(new SqlParameter("@Phone",phone));
            cmd.Parameters.Add(new SqlParameter("@Email",email));
            cmd.Parameters.Add(new SqlParameter("@Address",address));
            int result;
            try
            {
               if(cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                 result = cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
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

        public bool ExpiredUser(string username)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "ExpiredUser";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserId", username));
  
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

        public List<User> GetUserByRole(int role)
        {
            Console.WriteLine("vo service roi");
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetUserByRole";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Role", role));

            List<User> users = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {   if (users == null)
                    {
                        users = new List<User>();
                    }
                    users.Add(new User((string)reader["userId"], (string)reader["email"], (string)reader["fullname"], (string)reader["address"], (string)reader["phone"], (int)reader["gender"], (int)reader["role"], (DateTime)reader["date_reg"]));
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

        public User GetUserByUsername(string username)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetUserByUsername";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Username", username));

            User user = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new User((string)reader["userId"], (string)reader["password"], (string)reader["email"], (string)reader["fullname"], (string)reader["address"], (string)reader["phone"], (int)reader["gender"], (DateTime)reader["date_reg"]);
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

            return user;
        }

     
        public string model()
        {
            String sql = "Select * from tbl_user";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    return reader.GetString(1);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return "nothing";
        }

        
    }
}