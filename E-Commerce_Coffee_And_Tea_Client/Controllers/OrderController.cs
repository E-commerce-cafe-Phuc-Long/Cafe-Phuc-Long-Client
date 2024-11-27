using E_Commerce_Coffee_And_Tea_Client.Services.Cart;
using E_Commerce_Coffee_And_Tea_Client.Services.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICustomerService _customerService;
        public OrderController(
            ICartService cartService,
            ICustomerService customerService
            )
        {
            _cartService = cartService;
            _customerService = customerService;
        }

        [Route("")]
        public ActionResult Order()
        {
            var cartItems = _cartService.ShowCartItems();

            ViewBag.customer = _customerService.GetCustomerByUsername(User.Identity.Name);
            ViewBag.totalAmount = cartItems.Sum(item => item.thanhTien);
            List<string> CategoriesHasTeaDosage = new List<string> { "DM001", "DM002" };
            ViewBag.categoriesHasTeaDosage = CategoriesHasTeaDosage;

            return View(cartItems);
        }
    }
}