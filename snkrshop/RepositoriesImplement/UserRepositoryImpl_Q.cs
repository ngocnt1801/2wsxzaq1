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
    public partial class UserRepositoryImpl : UserRepository
    {
        public int LoginUser(string username, string password, bool isAdminLogin)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "CheckLogin";
            if (isAdminLogin)
            {
                sql = "LoginAdmin";
            }
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlParameter ruleOut = new SqlParameter("@Role",SqlDbType.Int,32) { Direction = ParameterDirection.Output };
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserName", username));
            cmd.Parameters.Add(new SqlParameter("@Password", password));
            cmd.Parameters.Add(ruleOut);
            int result;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                cmd.ExecuteScalar();
                //result = cmd.ExecuteNonQuery();
                result = (int)ruleOut.Value; //int.Parse(ruleOut.ToString());
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
        public bool SetRole(string username, int role)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "ChangeRole";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserId", username));
            cmd.Parameters.Add(new SqlParameter("@Role", role));
            int result;
            try
            {
                if (cnn.State == ConnectionState.Closed)
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
    }
}