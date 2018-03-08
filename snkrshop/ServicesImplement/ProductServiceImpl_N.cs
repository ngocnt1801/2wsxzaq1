using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.RepositoriesImplement;
using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class ProductServiceImpl : ProductService
    {
        const string FAIL = "fail";
        const string SUCCESS = "success";

        ImageRepository imageRepository;
        ProductSizeRepository productSizeRepository;
        ProductRepository productRepository;
        ProductColorRepository productColorRepository;

        public ProductServiceImpl()
        {
            this.imageRepository = new ImageRepositoryImpl();
            this.productSizeRepository = new ProductSizeRepositoryImpl();
            this.productRepository = new ProductRepositoryImpl();
            this.productColorRepository = new ProductColorRepositoryImpl();

        }

        public string AddProduct(string name, string brand, float price, string country, string description, string material, int categoryId, int quantity, string tag)
        {
            string result = FAIL;
            try
            {
                if (productRepository.AddProduct(name, brand, price, country, description, material, categoryId, quantity,tag))
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

        public string AddProductSize(int productId, int size)
        {
            string result = FAIL;
            try
            {
                if (productSizeRepository.AddProductSize(productId, size))
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

        public string DeleteImage(int imageId)
        {
            string result = FAIL;
            try
            {
                if (imageRepository.DeleteImageOfProduct(imageId))
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

        public User_Product GetProdctDetail(int productId)
        {
            try
            {
                User_Product product = productRepository.GetProductDetail(productId);
                product.Colors = productColorRepository.GetProductColor(product.ProductId);
                product.Sizes = productSizeRepository.GetProductSize(product.ProductId);
                product.Images = imageRepository.GetImageOfProduct(product.ProductId); 
                return product;
            }
            catch (Exception ex)
            {
                //ex.LogExceptionToFile();
                throw new Exception(ex.Message);


            }
        }

        public string UpdateProduct(int id, string name, string brand, float price, string country, string description, string material, int categoryId, int quantity,string tag)
        {
            string result = FAIL;
            try
            {
                if (productRepository.UpdateProduct(id, name, brand, price, country, description, material, categoryId, quantity,tag))
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

        public List<User_Product_Item> GetAllListProduct()
        {
            try
            {
               return this.productRepository.GetProductsSortByDiscount();
            }
            catch (Exception ex)
            {
                //ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
        }
    }
}