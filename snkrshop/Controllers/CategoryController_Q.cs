using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace snkrshop.Controllers
{
    public partial class CategoryController : ApiController
    {
        [Route("category/add")]
        [HttpPost]
        public string AddCategory(string name, string description, int parentId)
        {
            return categoryService.AddCategory(name, description, parentId);
        }
        [Route("category/update")]
        [HttpPost]
        public string UpdateCategory(int id, string name, string description, int parentId)
        {
            return categoryService.UpdateCategory(id, name, description, parentId);
        }
    }
}