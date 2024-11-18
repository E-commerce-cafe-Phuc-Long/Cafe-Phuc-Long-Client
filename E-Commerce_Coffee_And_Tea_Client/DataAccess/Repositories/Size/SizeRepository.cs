using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public SizeRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            this._context = context;
        }
        public List<Size> GetAll()
        {
            return _context.Sizes.ToList();
        }
        public List<Size> GetSizesByProductId(string productId)
        {
            return _context.ChiTietSanPhams
                .Where(ctsp => ctsp.maSP == productId)
                .Select(ctsp => ctsp.Size)
                .Distinct()
                .ToList();
        }
    }
}