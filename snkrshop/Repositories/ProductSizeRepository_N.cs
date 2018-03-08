using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Repositories
{
    partial interface ProductSizeRepository
    {
        bool AddProductSize(int productId, int size);
        List<Size> GetProductSize(int productId);
    }
}