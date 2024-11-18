using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess
{
    public interface IProductRepository
    {
        SanPham GetProductById(string productId);
        List<SanPham> GetProductByName(string productName);
        List<SanPham> GetProductList();
    }
}
