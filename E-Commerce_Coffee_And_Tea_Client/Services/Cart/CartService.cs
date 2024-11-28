using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public List<GioHang> ShowCartItemsByCustomerId(string customerId)
        {
            return _cartRepository.ShowCartItemsByCustomerId(customerId);
        }
        public void AddToCart(GioHang cart)
        {
            _cartRepository.AddToCart(cart);
        }
        public void DeleteItemInCart(GioHang cart)
        {
            _cartRepository.DeleteItemInCart(cart);
        }
        public void DeleteCart()
        {
            _cartRepository.DeleteCart();
        }
        //public string GenerateCartCode()
        //{
        //    var lastCartCode = _customerRepository.GetLastCartCode();

        //    // Nếu chưa có khách hàng thì khởi tạo mã NV: NV001
        //    if (string.IsNullOrEmpty(lastCartCode))
        //    {
        //        return "GH001";
        //    }

        //    var number = int.Parse(lastCartCode.Substring(2));

        //    return $"GH{(number + 1):D3}";
        //}
    }
}