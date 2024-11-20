using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Customer;
using E_Commerce_Coffee_And_Tea_Client.Services.Identity;
using E_Commerce_Coffee_And_Tea_Client.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    [RoutePrefix("profile")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [Route("")]
        public ActionResult Profile()
        {
            //tên người dùng từ cookie
            string username = User.Identity.Name;

            KhachHang customer = _customerService.GetCustomerByUsername(username);
            
            if (customer != null)
            {
                return View(customer);
            }
            return View();
        }

        [HttpPost]
        [Route("update-information")]
        public ActionResult UpdateInformation(UserInformationVM model)
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);

            // Lấy người dùng từ AppNetUser
            var user = userManager.FindByName(User.Identity.Name);

            // Kiểm tra sự tồn tại của người dùng
            if (user != null)
            {
                user.TenNguoiDung = model.TenKH;
                user.Email = model.Email;
                user.SoDT = model.SoDT;
                user.DiaChi = model.DiaChi;
                user.NgaySinh = model.NgaySinh;

                var updateResult = userManager.Update(user);

                if (updateResult.Succeeded)
                {
                    KhachHang customer = new KhachHang();
                    customer.username = User.Identity.Name;
                    customer.tenKH = model.TenKH;
                    customer.email = model.Email;
                    customer.soDT = model.SoDT;
                    customer.diaChi = model.DiaChi;
                    customer.ngaySinh = model.NgaySinh;

                    _customerService.UpdateProfile(customer);

                    TempData["Message"] = "Cập nhật thông tin thành công.";
                }
                else
                {
                    ModelState.AddModelError("Error", "Cập nhật thông tin thất bại.");
                }
            }
            else
            {
                ModelState.AddModelError("UserNotFound", "Không tìm thấy người dùng.");
            }
            return RedirectToRoute("Profile");
        }
        [HttpPost]
        [Route("change-password")]
        public ActionResult ChangePassword(UserAccountVM model)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var hash = new CustomPasswordHasher();

                // Lấy người dùng từ AppNetUser
                var user = userManager.FindByName(User.Identity.Name);

                var passwordHash = hash.VerifyHashedPassword(user.PasswordHash, model.OldPassword);
                
                // Kiểm tra sự tồn tại của người dùng và đúng password
                if (user != null && passwordHash == PasswordVerificationResult.Success)
                {
                    // Kiểm tra xác minh 2 mật khẩu mới
                    if (_customerService.VerifyNewPassword(model.NewPassword, model.ConfirmNewPassword) == true)
                    {
                        // Thay đổi thông tin người dùng AppNetUser
                        var changePasswordResult = userManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
                        if (changePasswordResult.Succeeded)
                        {
                            // Cập nhật thông tin vào Database
                            KhachHang customer = new KhachHang();

                            customer.username = User.Identity.Name;
                            customer.matKhau = model.NewPassword;

                            customer.tenKH = user.TenNguoiDung;
                            customer.email = user.Email;
                            customer.soDT = user.SoDT;
                            customer.diaChi = user.DiaChi;
                            customer.ngaySinh = user.NgaySinh;

                            bool result = _customerService.UpdateProfile(customer, true);
                            if (result == false)
                            {
                                ModelState.AddModelError("Error", "Lỗi trong quá trình thay đổi. Liên hệ bộ phận IT để hỗ trợ.");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("ChangePasswordError", "Đổi mật khẩu không thành công.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ConfirmPasswordError", "Mật khẩu mới và nhập lại mật khẩu mới không khớp.");
                    }
                }
                else 
                {
                    ModelState.AddModelError("UserNotFoundError", "Không tìm thấy người dùng.");
                }
            }
            TempData["Message"] = "Thay đổi mật khẩu thành công!";
            return RedirectToRoute("Profile");
        }
    }
}