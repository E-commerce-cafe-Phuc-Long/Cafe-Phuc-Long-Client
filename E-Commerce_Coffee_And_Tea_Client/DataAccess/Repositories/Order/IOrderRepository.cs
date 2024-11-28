using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Order
{
    public interface IOrderRepository
    {
        void GenerateOrder(DonHang order);
        void AddOrderDetails(ChiTietDonHang details);
        string GetLastOrderCode();
    }
}
