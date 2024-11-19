using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            this._repository = repository;
        }
        public void AddEmployee(NhanVien employee)
        {
            _repository.AddEmployee(employee);
        }
        public string GenerateEmployeeCode()
        {
            var lastEmplCode = _repository.GetLastEmployeeCode();

            // Nếu chưa có nhân viên thì khởi tạo mã NV: NV001
            if (string.IsNullOrEmpty(lastEmplCode))
            {
                return "NV001";
            }

            var number = int.Parse(lastEmplCode.Substring(2));

            return $"NV{(number + 1):D3}";
        }
    }
}