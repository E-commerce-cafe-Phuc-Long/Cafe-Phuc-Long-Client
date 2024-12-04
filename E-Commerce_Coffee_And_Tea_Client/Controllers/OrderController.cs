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
            var paymentMethods = _orderService.GetPaymentMethods();
            var cartItems = _cartService.ShowCartItemsByCustomerId(customerId);

            ViewBag.totalAmount = cartItems.Sum(item => item.thanhTien);
            List<string> CategoriesHasTeaDosage = new List<string> { "DM001", "DM002" };
            ViewBag.categoriesHasTeaDosage = CategoriesHasTeaDosage;

            decimal shippingFee = 12000;
            var orderVM = new OrderVM
            {
                MaTrangThai = "TTDH004",
                MaKH = customer.maKH,
                TenKH = customer.tenKH,
                DiaChi = customer.diaChi,
                SoDT = customer.soDT,
                CartItems = cartItems,
                TotalAmount = (decimal)cartItems.Sum(item => item.thanhTien),
                ShippingFee = shippingFee,
                TotalWithVAT = (decimal)cartItems.Sum(item => item.thanhTien) + shippingFee,
                PaymentMethod = paymentMethods,
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
        [Route("pending")]
        public ActionResult PendingOrders()
        {
            string username = User.Identity.Name;
            KhachHang customer = _customerService.GetCustomerByUsername(username);

            List<DonHang> pendingOrders = _orderService.GetPendingOrders(customer.maKH);
            return View(pendingOrders);
        }
        [Route("preparing")]
        public ActionResult PreparingOrders()
        {
            string username = User.Identity.Name;
            KhachHang customer = _customerService.GetCustomerByUsername(username);

            List<DonHang> preparingOrders = _orderService.GetPreparingOrders(customer.maKH);
            return View(preparingOrders);
        }
        [Route("completed")]
        public ActionResult CompletedOrders()
        {
            string username = User.Identity.Name;
            KhachHang customer = _customerService.GetCustomerByUsername(username);

            List<DonHang> completedOrders = _orderService.GetCompletedOrders(customer.maKH);
            return View(completedOrders);
        }
        [Route("canceled")]
        public ActionResult CanceledOrders()
        {
            string username = User.Identity.Name;
            KhachHang customer = _customerService.GetCustomerByUsername(username);

            List<DonHang> canceledOrders = _orderService.GetCanceledOrders(customer.maKH);
            return View(canceledOrders);
        }
    }
}