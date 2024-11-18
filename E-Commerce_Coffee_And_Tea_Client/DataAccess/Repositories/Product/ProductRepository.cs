using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public ProductRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            this._context = context;
        }
        public SanPham GetProductById(string productId)
        {
            return _context.SanPhams.FirstOrDefault(prod => prod.maSP == productId);
        }
        public List<SanPham> GetProductByName(string productName)
        {
            return _context.SanPhams.Where(prod => prod.tenSP.ToLower().Contains(productName.ToLower())).ToList();
        }
        public List<SanPham> GetProductList()
        {
            return _context.SanPhams.ToList();
        }
    }
}