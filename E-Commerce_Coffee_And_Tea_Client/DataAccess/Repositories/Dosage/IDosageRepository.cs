using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Dosage
{
    public interface IDosageRepository
    {
        List<LieuLuong> GetAll();
    }
}
