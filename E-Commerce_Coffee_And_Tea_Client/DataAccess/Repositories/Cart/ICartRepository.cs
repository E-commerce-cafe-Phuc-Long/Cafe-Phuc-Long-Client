using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Cart
{
    public interface ICartRepository
    {
        List<GioHang> ShowCartItemsByCustomerId(string customerId);
        void AddToCart(GioHang cart);
        void DeleteItemInCart(GioHang cart);
        void DeleteCart();
        //string GetLastCartCode();
    }
}
