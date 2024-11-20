using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Customer;
using E_Commerce_Coffee_And_Tea_Client.Services.Identity;
using E_Commerce_Coffee_And_Tea_Client.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : Controller
    {
        private readonly ICustomerService _customerService;
        public AuthController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #region Login

        [Route("login")]
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = TempData["RegisterSuccess"];
            return View();
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var hash = new CustomPasswordHasher();

                var user = userManager.FindByName(loginVM.Username) ?? userManager.FindByEmail(loginVM.Username);

                var passwordHash = hash.VerifyHashedPassword(user.PasswordHash, loginVM.Password);

                //if (user != null && userManager.CheckPassword(user, loginVM.Password))
                if (user != null && passwordHash == PasswordVerificationResult.Success)
                {
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties(), userIdentity);

                    return RedirectToRoute("Home");
                }
            }
            return View();
        }

        #endregion

        #region Register

        [Route("register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);

                var hash = new CustomPasswordHasher();
                var passwordHash = hash.HashPassword(registerVM.Password);

                var user = new ApplicationUser()
                {
                    UserName = registerVM.Username,
                    PasswordHash = passwordHash,
                    Email = registerVM.Email,
                    SoDT = registerVM.PhoneNumber,
                    TenNguoiDung = registerVM.Username,
                    MaVaiTro = "Customer",
                };

                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    //Tạo mã khách hàng
                    string newCustomerCode = _customerService.GenerateCustomerCode();

                    // Lưu vào bảng KhachHang
                    KhachHang khachHang = new KhachHang()
                    {
                        maKH = newCustomerCode,
                        username = user.UserName,
                        matKhau = user.PasswordHash,
                        email = user.Email,
                        soDT = user.SoDT,
                        tenKH = user.UserName,
                    };
                    _customerService.AddCustomer(khachHang);
                    TempData["RegisterSuccess"] = "Đăng ký thành công. Vui lòng đăng nhập!";
                }
                return RedirectToRoute("Login");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Date");
                return View();
            }
        }
        #endregion

        #region Logout

        [Route("logout")]
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToRoute("Login");
        }

        #endregion
    }
}