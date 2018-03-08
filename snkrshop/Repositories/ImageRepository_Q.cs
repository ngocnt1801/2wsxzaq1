using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface ImageRepository
    {
        bool AddImageToProduct(string url, int productId);
        
    }
}
