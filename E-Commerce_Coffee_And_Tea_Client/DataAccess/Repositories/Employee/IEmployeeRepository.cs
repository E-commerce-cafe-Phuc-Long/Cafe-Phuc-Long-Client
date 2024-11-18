using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        NhanVien GetEmployeeByUsername(string username);
        void AddEmployee(NhanVien employee);
        List<NhanVien> GetAllEmployees();
        bool IsUsernameExists(string username);
    }
}
