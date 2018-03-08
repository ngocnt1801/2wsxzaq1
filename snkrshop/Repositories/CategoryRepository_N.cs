using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface CategoryRepository
    {
        bool DeleteCategory(int categoryId);
        List<Category> GetAllCategory();
    }
}