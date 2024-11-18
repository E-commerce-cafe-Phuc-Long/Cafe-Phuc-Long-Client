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
            return _context.SanPhams
                .FirstOrDefault(prod => prod.maSP == productId);
        }
        public List<ChiTietSanPham> GetProductByName(string productName)
        {
            return _context.ChiTietSanPhams
                .Where(prod => prod.SanPham.tenSP.ToLower().Contains(productName.ToLower()))
                .GroupBy(ctsp => ctsp.maSP)
                //.Select(group => group.OrderByDescending(ctsp => ctsp.maCTSP).FirstOrDefault())
                .Select(group => group.OrderBy(ctsp => ctsp.maCTSP).FirstOrDefault())
                .ToList();
        }
        public List<SanPham> GetProductList()
        {
            return _context.SanPhams.ToList();
        }
        public List<ChiTietSanPham> GetLastProductDetailByIds(List<string> productIds)
        {
            return _context.ChiTietSanPhams
                .Where(prod => productIds.Contains(prod.maSP))
                .GroupBy(ctsp => ctsp.maSP)
                //.Select(group => group.OrderByDescending(ctsp => ctsp.maCTSP).FirstOrDefault())
                .Select(group => group.OrderBy(ctsp => ctsp.maCTSP).FirstOrDefault())
                .ToList();  
        }
        public ChiTietSanPham GetProductDetailByIdAndSizeId(string productId, string sizeId)
        {
            return _context.ChiTietSanPhams
                .FirstOrDefault(prod => prod.maSP == productId && prod.Size.maSize == sizeId);
        }
    }
}