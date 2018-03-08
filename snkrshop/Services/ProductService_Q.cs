using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Services
{
    partial interface ProductService
    {
        List<User_Product_Item> GetListProduct(int sortByPrice, int sortById);
        //List<User_Product_Item> GetSearchProduct(string searchString);
        string RatingProduct(int productId, string userId, int rate);
        List<User_Product_Item> GetProductByCategory(int categoryId);
        string DeleteProduct(int productId);
        string AddProductColor(int productId, string color);
        IEnumerable<User_Product_Item> SearchProduct(string searchString);
    }
}
