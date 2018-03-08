using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Services
{
    partial interface CategoryService
    {
        string DeleteCategory(int categoryId);
        List<Category> GetAllCategory();
    }
}