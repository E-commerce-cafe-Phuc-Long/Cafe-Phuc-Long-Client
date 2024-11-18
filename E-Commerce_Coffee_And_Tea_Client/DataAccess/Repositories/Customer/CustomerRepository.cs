using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public CustomerRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            this._context = context;
        }
        public KhachHang GetCustomerByUsername(string username)
        {
            return _context.KhachHangs.FirstOrDefault(customer => customer.username == username);
        }
        public void AddCustomer(KhachHang customer)
        {
            _context.KhachHangs.InsertOnSubmit(customer);
            _context.SubmitChanges();
        }
        public List<KhachHang> GetAllCustomers()
        {
            return _context.KhachHangs.ToList();
        }
        public bool IsUsernameExists(string username)
        {
            return _context.KhachHangs.Any(customer => customer.username == username);
        }
    }
}