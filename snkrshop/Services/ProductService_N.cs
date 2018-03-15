using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Services
{
    partial interface ProductService
    {
        string DeleteImage(int imageId);
        string AddProductSize(int productId, int size);
        string AddProduct(string name, string brand, float price, string country, string description, string material, int categoryId, int quantity,string tag);
        string UpdateProduct(int id, string name, string brand, float price, string country, string description, string material, int categoryId, int quantity, string tag);
        User_Product GetProdctDetail(int productId);
        Admin_Product GetProductDetailForAdmin(int productId);
        List<User_Product_Item> GetAllListProduct();
        List<Product> GetAllProductForAdmin();
        List<User_Product> GetListCartProduct(int[] productIds);
    }
}