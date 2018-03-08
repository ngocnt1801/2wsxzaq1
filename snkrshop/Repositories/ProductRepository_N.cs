using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface ProductRepository
    {
        bool AddProduct(string name,string brand, float price, string country, string description, string material, int categoryId, int quantity,string tag);
        bool UpdateProduct(int id, string name, string brand, float price, string country, string description, string material, int categoryId, int quantity, string tag);
        User_Product GetProductDetail(int productId);
        List<User_Product_Item> GetProductsSortByDiscount();
        
    }
}