using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Dosage
{
    public class DosageRepository : IDosageRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public DosageRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            this._context = context;
        }
        public List<LieuLuong> GetAll()
        {
            return _context.LieuLuongs.ToList();
        }
    }
}