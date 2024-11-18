using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Size
{
    public interface ISizeService
    {
        List<DataAccess.Size> GetAll();
        List<DataAccess.Size> GetSizesByProductId(string productId);
    }
}
