using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using E_Commerce_Coffee_And_Tea_Client.Services.Identity;
using E_Commerce_Coffee_And_Tea_Client.Services.Employee;
using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using Unity;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories;
using System.ComponentModel;

[assembly: OwinStartup(typeof(E_Commerce_Coffee_And_Tea_Client.Startup))]

namespace E_Commerce_Coffee_And_Tea_Client
{
    public class Startup
    {
        private IEmployeeService _employeeService;
        public void Configuration(IAppBuilder app)
        {
            E_Commerce_Coffee_And_TeaDataContext context = new E_Commerce_Coffee_And_TeaDataContext();
            IEmployeeRepository repository = new EmployeeRepository(context);
            _employeeService = new EmployeeService(repository);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/auth/login"),
                ExpireTimeSpan = TimeSpan.FromDays(14), // Thời hạn cookie 14 ngày
                SlidingExpiration = true, // Gia hạn thời gian nếu người dùng hoạt động
                CookieSecure = CookieSecureOption.Always, // Chỉ gửi cookie qua HTTPS
                CookieHttpOnly = true // Ngăn truy cập cookie qua JavaScript
            });
            this.CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            // Tạo Role Manager và User Manager
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(new ApplicationDbContext()));
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Kiểm tra và tạo vai trò Admin
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new ApplicationRole("Admin");
                roleManager.Create(role);
            }

            // Kiểm tra và tạo vai trò Manager
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new ApplicationRole("Manager");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new ApplicationRole("Customer");
                roleManager.Create(role);
            }

            // Kiểm tra nếu tài khoản Admin chưa có, tạo tài khoản Admin
            var adminUser = userManager.FindByName("admin@example.com");
            if (adminUser == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    TenNguoiDung = "Admin",
                    MaVaiTro = "Admin"
                };
                var result = userManager.Create(user, "123456");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");

                    //Tạo mã nhân viên
                    string newEmployeeCode = _employeeService.GenerateEmployeeCode();

                    // Lưu vào bảng NhanVien
                    NhanVien nhanVien = new NhanVien()
                    {
                        maNV = newEmployeeCode,
                        username = user.UserName,
                        matKhau = user.PasswordHash,
                        tenNV = user.TenNguoiDung,
                        maVaiTro = "Admin"
                    };
                    _employeeService.AddEmployee(nhanVien);
                }
            }

            // Kiểm tra nếu tài khoản Manager chưa có, tạo tài khoản Manager
            var managerUser = userManager.FindByName("manager@example.com");
            if (managerUser == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "manager@example.com",
                    Email = "manager@example.com",
                    TenNguoiDung = "Manager",
                    MaVaiTro = "Manager"
                };
                var result = userManager.Create(user, "123456");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");

                    //Tạo mã nhân viên
                    string newEmployeeCode = _employeeService.GenerateEmployeeCode();

                    // Lưu vào bảng NhanVien
                    NhanVien nhanVien = new NhanVien()
                    {
                        maNV = newEmployeeCode,
                        username = user.UserName,
                        matKhau = user.PasswordHash,
                        tenNV = user.TenNguoiDung,
                        maVaiTro = "Manager"
                    };
                    _employeeService.AddEmployee(nhanVien);
                }
            }
        }
    }
}
