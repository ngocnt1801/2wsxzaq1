using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class UserServiceImpl : UserService
    {
        private const string ADMIN = "admin";
        private const string STAFF = "staff";
        public string LoginAdmin(string username, string password)
        {
            string result = FAIL;
            try
            {
                int role = userRepository.LoginUser(username, password, true);
                if (role == 1)
                {
                    result = ADMIN;
                }
                else
                {
                    if (role == 2)
                    {
                        result = STAFF;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }

        public string LoginUser(string username, string password)
        {
            string result = FAIL;
            try
            {
                if (userRepository.LoginUser(username, password, false) > 0)
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }
        public string SetRole(string username, int role)
        {
            string result = FAIL;
            try
            {
                if (userRepository.SetRole(username, role))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }

        
    }
}