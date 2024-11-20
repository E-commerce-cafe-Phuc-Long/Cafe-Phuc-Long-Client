using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Customer
{
    public interface ICustomerService
    {
        KhachHang GetCustomerByUsername(string username);
        void AddCustomer(KhachHang customer);
        string GenerateCustomerCode();
        bool UpdateProfile(KhachHang updatedCustomer, bool updateAccount = false);
        bool VerifyNewPassword(string newPassword, string confirmNewPassword);
    }
}
