using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Cart;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Order;
using E_Commerce_Coffee_And_Tea_Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        public OrderService(
            IOrderRepository orderRepository,
            ICartRepository cartRepository
            )
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }
        public void GenerateOrder(OrderVM orderVM)
        {
            var cartItems = _cartRepository.ShowCartItemsByCustomerId(orderVM.MaKH);
            string orderCode = GenerateOrderCode();
            var order = new DonHang
            {
                maDH = orderCode,
                ngayLapDH = DateTime.Now.Date,
                tongTien = (decimal)cartItems.Sum(item => item.thanhTien),
                maPT = orderVM.MaPhuongThucThanhToan,
                maKH = orderVM.MaKH,
                maNV = null,
                //maTT = orderVM.MaTrangThai,
                maTT = "TTDH001"
            };
            _orderRepository.GenerateOrder(order);
            //DonHang donHang = new DonHang();
            //donHang.maDH = GenerateOrderCode();
            //donHang.ngayLapDH = DateTime.Now.Date;
            //donHang.tongTien = orderVM.TotalAmount;
            //donHang.maPT = orderVM.PaymentMethod;
            //donHang.maKH = orderVM.MaKH;
            //donHang.maNV = null;
            //donHang.maTT = orderVM.maTrangThai;

            //foreach (var item in orderVM.CartItems)
            //{
            //    var chiTietDonHang = new ChiTietDonHang
            //    {
            //        maDH = order.maDH,
            //        maCTSP = item.maCTSP,
            //        soLuongDatHang = item.soLuongDatHang,
            //        donGia = item.donGia,
            //        thanhTien = item.thanhTien,
            //        lieuLuongDa = item.lieuLuongDa,
            //        lieuLuongNgot = item.lieuLuongNgot,
            //        lieuLuongTra = item.lieuLuongTra,
            //    };

            //    AddOrderDetails(chiTietDonHang);
            //}
            foreach (var item in cartItems)
            {
                var chiTietDonHang = new ChiTietDonHang
                {
                    maDH = orderCode,
                    maCTSP = item.maCTSP,
                    soLuongDatHang = item.soLuongDatHang,
                    donGia = item.donGia,
                    thanhTien = item.thanhTien,
                    lieuLuongDa = item.lieuLuongDa,
                    lieuLuongNgot = item.lieuLuongNgot,
                    lieuLuongTra = item.lieuLuongTra,
                };

                AddOrderDetails(chiTietDonHang);
            }
        }
        public void AddOrderDetails(ChiTietDonHang details)
        {
            _orderRepository.AddOrderDetails(details);
        }
        public string GenerateOrderCode()
        {
            var lastOrderCode = _orderRepository.GetLastOrderCode();

            // Nếu chưa có đơn hàng thì khởi tạo mã DH: DH001
            if (string.IsNullOrEmpty(lastOrderCode))
            {
                return "DH001";
            }

            var number = int.Parse(lastOrderCode.Substring(2));

            return $"DH{(number + 1):D3}";
        }

        //Payment Method
        public List<PhuongThucThanhToan> GetPaymentMethods()
        {
            return _orderRepository.GetPaymentMethods();
        }
    }
}