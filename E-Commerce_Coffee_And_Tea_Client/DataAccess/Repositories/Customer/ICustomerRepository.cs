using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess
{
    public interface ICustomerRepository
    {
        KhachHang GetCustomerByUsername(string username);
        void AddCustomer(KhachHang customer);
        List<KhachHang> GetAllCustomers();
        bool IsUsernameExists(string username);
    }
}