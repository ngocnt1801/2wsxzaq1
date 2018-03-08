using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.RepositoriesImplement;
using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class UserServiceImpl : UserService
    {
        const string SUCCESS = "success";
        const string FAIL = "fail";
        const string DUPLICATE = "duplicate";
        UserRepository userRepository;

        public UserServiceImpl()
        {
            userRepository = new UserRepositoryImpl();
        }

        public string DeleteAccount(string username)
        {
            string result = FAIL;
            try
            {
                if (userRepository.ExpiredUser(username))
                {
                    result = SUCCESS;
                }

            }
            catch (Exception ex)
            {
                result = FAIL;
                ex.LogExceptionToFile();
            }
            return result;
        }

        public List<User> GetUserByRole(int role)
        {
            try
            {
                Console.WriteLine("vo service roi");
                return this.userRepository.GetUserByRole(role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ex.LogExceptionToFile();
            }
            return null;
        }

        public User GetUserInformation(string username)
        {
            
            try
            {
                return this.userRepository.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ex.LogExceptionToFile();
            }
            return null;
        }

        public string Register(string username, string password, string fullname, string phone, string email, string address)
        {
            string result = FAIL;
            try
            {
               if ( userRepository.AddUser(username, password, fullname, email, phone, address))
                {
                    result = SUCCESS;
                }

            }
            catch (SqlException se)
            {
                if (se.Message.Contains("duplicate"))
                {
                    result =  DUPLICATE;
                }
                se.LogExceptionToFile();
            }catch (Exception ex)
            {
                result = FAIL;
                ex.LogExceptionToFile();
            }
            return result;
        }
    }
}