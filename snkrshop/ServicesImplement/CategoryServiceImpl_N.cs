using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.RepositoriesImplement;
using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class CategoryServiceImpl : CategoryService
    {
        const string FAIL = "fail";
        const string SUCCESS = "success";
        CategoryRepository categoryRepository;

        public CategoryServiceImpl()
        {
            this.categoryRepository = new CategoryRepositoryImpl();
        }

        public string DeleteCategory(int categoryId)
        {
            string result = FAIL;
            try
            {
                if (categoryRepository.DeleteCategory(categoryId))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Category> GetAllCategory()
        {
           
            try
            {
                return this.categoryRepository.GetAllCategory();
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
        }
    }
}