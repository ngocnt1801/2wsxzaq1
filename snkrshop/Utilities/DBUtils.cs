using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace snkrshop.Utilities
{
    public class DBUtils
    {
        public static SqlConnection GetConnection()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["SnkrDB"].ConnectionString;
            Console.WriteLine("Connection string:" + strConnection);
            return new SqlConnection(strConnection);
        }
    }
}