using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public CategoryRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            _context = context;
        }
        public List<DanhMuc> GetCategoriesList()
        {
            return _context.DanhMucs.ToList();
        }
    }
}