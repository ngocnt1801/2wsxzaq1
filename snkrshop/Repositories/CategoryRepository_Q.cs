using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface CategoryRepository
    {
        bool AddCategory(Category theNewCategory);
        bool UpdateCategory(Category theEdited);
    }
}
