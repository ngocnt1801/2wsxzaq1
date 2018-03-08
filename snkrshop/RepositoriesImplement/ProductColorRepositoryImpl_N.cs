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
    public partial class ProductColorRepositoryImpl : ProductColorRepository
    {
        public List<Color> GetProductColor(int productId)
        {
            SqlConnection cnn = DBUtils.GetConnection();
            string sql = "GetProductColor";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProductId", productId));

            List<Color> productColors = null;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (productColors == null)
                    {
                        productColors = new List<Color>();
                    }
                    productColors.Add(new Color((int)reader["colorId"], (string)reader["colorName"]));
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

            return productColors;
        }
    }
}