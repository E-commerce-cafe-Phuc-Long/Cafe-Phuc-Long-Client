using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.ViewModels
{
    public class OrderVM
    {
        // Thông tin khách hàng
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public string GhiChu { get; set; }
        public bool YeuCauXuatHoaDon { get; set; }

        // Giỏ hàng
        public List<GioHang> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalWithVAT { get; set; }

        // Phương thức thanh toán
        public List<PhuongThucThanhToan> PaymentMethod { get; set; }
        public string MaPhuongThucThanhToan { get; set; }

        // Trạng thái đơn hàng
        public string MaTrangThai { get; set; }

        // Điều khoản và chính sách
        public bool AgreeWithPolicy { get; set; }
    }
}