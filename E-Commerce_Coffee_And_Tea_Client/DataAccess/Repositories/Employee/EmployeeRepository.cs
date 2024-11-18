using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public EmployeeRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            this._context = context;
        }
        public NhanVien GetEmployeeByUsername(string username)
        {
            return _context.NhanViens.FirstOrDefault(empl => empl.username == username);
        }
        public void AddEmployee(NhanVien employee)
        {
            _context.NhanViens.InsertOnSubmit(employee);
            _context.SubmitChanges();
        }
        public List<NhanVien> GetAllEmployees()
        {
            return _context.NhanViens.ToList();
        }
        public bool IsUsernameExists(string username)
        {
            return _context.NhanViens.Any(empl => empl.username == username);
        }
    }
}