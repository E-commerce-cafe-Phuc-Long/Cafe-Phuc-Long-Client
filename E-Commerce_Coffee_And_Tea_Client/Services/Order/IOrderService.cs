using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Order;
using E_Commerce_Coffee_And_Tea_Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Order
{
    public interface IOrderService
    {
        void GenerateOrder(OrderVM orderVM);
        void AddOrderDetails(ChiTietDonHang details);
        string GenerateOrderCode();

        //Payment Method
        List<PhuongThucThanhToan> GetPaymentMethods();
        List<ChiTietDonHang> GetOrderDetails(string orderId);
        List<DonHang> GetOrders(string customerId);
        List<DonHang> GetPendingOrders(string customerId);
        List<DonHang> GetPreparingOrders(string customerId);
        List<DonHang> GetCompletedOrders(string customerId);
        List<DonHang> GetCanceledOrders(string customerId);
    }
}
