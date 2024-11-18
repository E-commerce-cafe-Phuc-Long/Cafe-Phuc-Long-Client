using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Product
{
    public interface IProductService
    {
        SanPham GetProductById(string productId);
        List<ChiTietSanPham> GetProductByName(string productName);
        List<SanPham> GetProductList();
        List<ChiTietSanPham> GetLastProductDetailByIds(List<string> productIds);
        ChiTietSanPham GetProductDetailByIdAndSizeId(string productId, string sizeId);
    }
}
