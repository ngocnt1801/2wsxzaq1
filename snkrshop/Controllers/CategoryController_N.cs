using snkrshop.Models;
using snkrshop.Services;
using snkrshop.ServicesImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class CategoryController : ApiController
    {
        CategoryService categoryService = new CategoryServiceImpl();

        [Route("category/delete")]
        [HttpGet]
        public string DeleteCategory(int categoryId)
        {
            return categoryService.DeleteCategory(categoryId);
        }

        [Route("category/all")]
        [HttpGet]
        public List<Category> GetAll()
        {
            return this.categoryService.GetAllCategory();
        }
    }
}
