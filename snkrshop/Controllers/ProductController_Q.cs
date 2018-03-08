using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class ProductController : ApiController
    {
        [Route("product")]
        [HttpGet]
        public List<User_Product_Item> GetListProduct(int sortByPrice, int sortById)
        {
            return productService.GetListProduct(sortByPrice, sortById);
        }
        [Route("product/search")]
        [HttpGet]
        public IEnumerable<User_Product_Item> GetSearchProduct(string searchString)
        {
            
            return productService.SearchProduct(searchString);
        }
        [Route("product/rating")]
        [HttpPost]
        public string RatingProduct(int productId, string userId, int rate)
        {
            return productService.RatingProduct(productId, userId, rate);
        }
        [Route("product/get/category")]
        [HttpGet]
        public List<User_Product_Item> GetProductByCategory(int categoryId)
        {
            return productService.GetProductByCategory(categoryId);
        }
        [Route("product/delete")]
        [HttpGet]
        public string DeleteProduct(int productId)
        {
            return productService.DeleteProduct(productId);
        }
        [Route("product/add/color")]
        [HttpPost]
        public string AddProductColor(int productId, string color)
        {
            return productService.AddProductColor(productId, color);
        }
    }
}