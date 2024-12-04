using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public OrderRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            _context = context;
        }
        public void GenerateOrder(DonHang order)
        {
            _context.DonHangs.InsertOnSubmit(order);
            _context.SubmitChanges();
        }
        public void AddOrderDetails(ChiTietDonHang details)
        {
            _context.ChiTietDonHangs.InsertOnSubmit(details);
            _context.SubmitChanges();
        }
        public string GetLastOrderCode()
        {
            return _context.DonHangs
                .OrderByDescending(dh => dh.maDH)
                .Select(dh => dh.maDH)
                .FirstOrDefault();
        }
        //Payment Method
        public List<PhuongThucThanhToan> GetPaymentMethods()
        {
            return _context.PhuongThucThanhToans.ToList();
        }
        public List<ChiTietDonHang> GetOrderDetails(string orderId)
        {
            return _context.ChiTietDonHangs
                .Where(ct => ct.maDH == orderId)
                .ToList();
        }
        public List<DonHang> GetOrders(string customerId)
        {
            return _context.DonHangs
                .Where(dh => dh.maKH ==  customerId)
                .ToList();
        }
        public List<DonHang> GetPendingOrders(string customerId)
        {
            return _context.DonHangs
                .Where(dh => dh.maKH == customerId && dh.maTT == "TTDH004")
                .ToList();
        }
        public List<DonHang> GetPreparingOrders(string customerId)
        {
            return _context.DonHangs
                .Where(dh => dh.maKH == customerId && dh.maTT == "TTDH001")
                .ToList();
        }
        public List<DonHang> GetCompletedOrders(string customerId)
        {
            return _context.DonHangs
                .Where(dh => dh.maKH == customerId && dh.maTT == "TTDH002")
                .ToList();
        }
        public List<DonHang> GetCanceledOrders(string customerId)
        {
            return _context.DonHangs
                .Where(dh => dh.maKH == customerId && dh.maTT == "TTDH003")
                .ToList();
        }
    }
}