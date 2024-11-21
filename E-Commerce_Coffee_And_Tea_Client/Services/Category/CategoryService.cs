using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Category;
using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public List<DanhMuc> GetCategoriesList()
        {
            return _repository.GetCategoriesList();
        }
    }
}