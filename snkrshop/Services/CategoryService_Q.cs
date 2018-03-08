using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Services
{
    partial interface CategoryService
    {
        string AddCategory( string name, string description, int parentId);
        string UpdateCategory(int id, string name, string description, int parentId);
    }
}
