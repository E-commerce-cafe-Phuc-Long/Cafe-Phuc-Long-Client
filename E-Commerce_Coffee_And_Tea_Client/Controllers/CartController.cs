using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Cart;
using E_Commerce_Coffee_And_Tea_Client.Services.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    [RoutePrefix("cart")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICustomerService _customerService;
        public CartController(
            ICartService cartService,
            ICustomerService customerService
            )
        {
            _cartService = cartService;
            _customerService = customerService;
        }
        // GET: Cart
        public ActionResult _PartialPage_Cart()
        {
            return View();
        }
        [HttpGet]
        [Route("delete-cart-item")]
        public ActionResult DeleteItem(string maCTSP)
        {
            var customer = _customerService.GetCustomerByUsername(User.Identity.Name);
            GioHang cart = new GioHang();
            cart.maKH = customer.maKH;
            cart.maCTSP = maCTSP;
            _cartService.DeleteItemInCart(cart);
            return RedirectToRoute("Order");
        }
    }
}