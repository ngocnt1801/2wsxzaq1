using snkrshop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface ProductRepository
    {
        List<User_Product_Item> GetListProduct( int sortByPrice, int sortById);
        //List<User_Product_Item> GetSearchProduct(string searchString);
        bool RatingProduct(int productId, string userId, int rate);
        List<User_Product_Item> GetProductByCategory(int categoryId);
        bool DeleteProduct(int productId);
        bool AddProductColor(int productId, string color);
        IEnumerable<User_Product_Item> SearchProduct(string searchString);
    }
}
