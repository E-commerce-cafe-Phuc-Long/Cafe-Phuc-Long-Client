using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories;
using E_Commerce_Coffee_And_Tea_Client.Services.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public KhachHang GetCustomerByUsername(string username)
        {
            return _customerRepository.GetCustomerByUsername(username);
        }
        public void AddCustomer(KhachHang customer)
        {
            _customerRepository.AddCustomer(customer);
        }
        public string GenerateCustomerCode()
        {
            var lastCustomerCode = _customerRepository.GetLastCustomerCode();

            // Nếu chưa có khách hàng thì khởi tạo mã NV: NV001
            if (string.IsNullOrEmpty(lastCustomerCode))
            {
                return "KH001";
            }

            var number = int.Parse(lastCustomerCode.Substring(2));

            return $"KH{(number + 1):D3}";
        }
        public bool UpdateProfile(KhachHang updatedCustomer, bool updateAccount = false)
        {
            if (updateAccount == true)
            {
                var hash = new CustomPasswordHasher();

                string hashNewPassword = hash.HashPassword(updatedCustomer.matKhau);
                updatedCustomer.matKhau = hashNewPassword;
            }

            bool result = _customerRepository.UpdateProfile(updatedCustomer);
            
            if (result == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerifyNewPassword(string newPassword, string confirmNewPassword)
        {
            var hash = new CustomPasswordHasher();
            
            string hashNewPassword = hash.HashPassword(newPassword);
            string hashConfirmNewPassword = hash.HashPassword(confirmNewPassword);

            if (hashNewPassword == hashConfirmNewPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}