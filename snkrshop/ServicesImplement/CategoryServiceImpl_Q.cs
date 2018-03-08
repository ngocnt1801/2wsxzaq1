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
        //const string FAIL = "fail";
        //const string SUCCESS = "success";
        //CategoryRepository categoryRepository;

        public string AddCategory(string name, string description, int parentId)
        {
            string result = FAIL;
            Category ct = new Category(name, description, parentId);
            try
            {
                if (categoryRepository.AddCategory(ct))
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

        public string UpdateCategory(int id, string name, string description, int parentId)
        {
            string result = FAIL;
            Category ct = new Category(name, description, parentId);
            ct.Id=id;
            try
            {
                if (categoryRepository.UpdateCategory(ct))
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
    }
}