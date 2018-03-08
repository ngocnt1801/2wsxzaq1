using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using snkrshop.Models;

namespace snkrshop.Repositories
{
    partial interface ImageRepository
    {
        bool DeleteImageOfProduct(int imageId);
        string GetFirstImageOfProduct(int productId);
        List<Image> GetImageOfProduct(int productId);
    }
}