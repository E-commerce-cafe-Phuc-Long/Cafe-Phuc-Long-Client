using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Cart;
using E_Commerce_Coffee_And_Tea_Client.Services.Customer;
using E_Commerce_Coffee_And_Tea_Client.Services.Order;
using E_Commerce_Coffee_And_Tea_Client.ViewModels;
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
        private readonly IOrderService _orderService;
        public OrderController(
            ICartService cartService,
            ICustomerService customerService,
            IOrderService orderService
            )
        {
            _cartService = cartService;
            _customerService = customerService;
            _orderService = orderService;
        }

        [Route("")]
        public ActionResult Order()
        {
            var customer = _customerService.GetCustomerByUsername(User.Identity.Name);
            var customerId = customer.maKH;

            var cartItems = _cartService.ShowCartItemsByCustomerId(customerId);

            ViewBag.totalAmount = cartItems.Sum(item => item.thanhTien);
            List<string> CategoriesHasTeaDosage = new List<string> { "DM001", "DM002" };
            ViewBag.categoriesHasTeaDosage = CategoriesHasTeaDosage;

            decimal shippingFee = 12000;
            var orderVM = new OrderVM
            {
                maTrangThai = "TTDH001",
                MaKH = customer.maKH,
                TenKH = customer.tenKH,
                DiaChi = customer.diaChi,
                SoDT = customer.soDT,
                CartItems = cartItems,
                TotalAmount = (decimal)cartItems.Sum(item => item.thanhTien),
                ShippingFee = shippingFee,
                TotalWithVAT = (decimal)cartItems.Sum(item => item.thanhTien) + shippingFee
            };

            return View(orderVM);
        }
        [HttpPost]
        [Route("create-order")]
        public ActionResult CreateOrder(OrderVM orderVM)
        {
            _orderService.GenerateOrder(orderVM);
            _cartService.DeleteCart();
            return RedirectToRoute("Home");
        }
    }
}