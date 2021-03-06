﻿using snkrshop.Models;
using snkrshop.Services;
using snkrshop.ServicesImplement;
using System.Collections.Generic;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class ProductController : ApiController
    {
        ProductService productService = new ProductServiceImpl();

        [Route("product/delete/image")]
        [HttpGet]
        public string DeleteImage(int imageId)
        {
            return productService.DeleteImage(imageId);
        }

        [Route("product/add/size")]
        [HttpPost]
        public string AddProductSize(int productId, int size)
        {
            return productService.AddProductSize(productId, size);
        }

        [Route("product/add")]
        [HttpPost]
        public string AddProduct(string name, string brand, float price, string country, string description, string material, int categoryId, int quantity,string tag)
        {
            return this.productService.AddProduct(name, brand, price, country, description, material, categoryId, quantity,tag);
        }

        [Route("product/update")]
        [HttpPost]
        public string Update(int id, string name, string brand, float price, string country, string description, string material, int categoryId, int quantity,string tag)
        {
            return this.productService.UpdateProduct(id, name, brand, price, country, description, material, categoryId, quantity,tag);
        }

        //[Route("product/{productId}")]
        //[HttpGet]
        //public User_Product GetDetail(int productId)
        //{

        //    return this.productService.GetProdctDetail(productId);
        //}

        [Route("product/{productId}")]
        [HttpGet]
        public User_Product GetDetail(int productId)
        {

            return this.productService.GetProdctDetail(productId);
        }

        [Route("admin/product")]
        [HttpGet]
        public List<Product> GetAll()
        {
            return this.productService.GetAllProductForAdmin();
        }

        [Route("admin/product/{productId}")]
        [HttpGet]
        public Admin_Product GetAdminDetailProduct(int productId)
        {
            return this.productService.GetProductDetailForAdmin(productId);
        }

        [Route("cart/products")]
        [HttpGet]
        public List<User_Product> GetProductForCart(int[] id)
        {
            return this.productService.GetListCartProduct(id);
        }
    }
}
