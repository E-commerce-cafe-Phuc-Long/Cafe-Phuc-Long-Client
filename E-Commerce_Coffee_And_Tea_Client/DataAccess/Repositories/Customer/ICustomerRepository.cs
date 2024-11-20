using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        KhachHang GetCustomerByUsername(string username);
        //List<KhachHang> GetAllCustomers();
        //bool IsUsernameExists(string username);
        void AddCustomer(KhachHang customer);
        string GetLastCustomerCode();
        bool UpdateProfile(KhachHang updatedCustomer);
    }
}