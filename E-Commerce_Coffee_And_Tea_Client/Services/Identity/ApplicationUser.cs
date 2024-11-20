using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string TenNguoiDung { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string MaVaiTro { get; set; }
    }
}