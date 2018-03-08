using snkrshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snkrshop.Repositories
{
    partial interface ProductColorRepository
    {
        List<Color> GetProductColor(int productId);
    }
}
