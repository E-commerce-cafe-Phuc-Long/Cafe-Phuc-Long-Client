using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce_Coffee_And_Tea_Client.ApiControllers.Cart
{
    [RoutePrefix("api/cart")]
    public class APICartController : ApiController
    {
        private readonly ICartService _cartService;
        public APICartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // POST: api/cart/add-to-cart
        [Route("add-to-cart")]
        [HttpPost]
        public IHttpActionResult AddToCart(GioHang cart)
        {
            if (cart != null)
            {
                _cartService.AddToCart(cart);
                return Json(new { success = true, message = "Thành công!", cart });
            }
            else
            {
                return Json(new { success = false, message = "Thất bại" });
            }
        }
    }
}
