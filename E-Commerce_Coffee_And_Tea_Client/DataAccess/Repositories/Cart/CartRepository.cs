using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly E_Commerce_Coffee_And_TeaDataContext _context;
        public CartRepository(E_Commerce_Coffee_And_TeaDataContext context)
        {
            _context = context;
        }
        public List<GioHang> ShowCartItems()
        {
            return _context.GioHangs.ToList();
        }
        public void AddToCart(GioHang cart)
        {
            var existingCart = _context.GioHangs.SingleOrDefault(c => cart.maKH == c.maKH && cart.maCTSP == c.maCTSP);
            if (existingCart != null)
            {
                existingCart.soLuongDatHang += cart.soLuongDatHang;
                existingCart.thanhTien = cart.soLuongDatHang * cart.donGia;
                existingCart.lieuLuongDa = cart.lieuLuongDa;
                existingCart.lieuLuongTra = cart.lieuLuongTra;
                existingCart.lieuLuongNgot = cart.lieuLuongNgot;

                _context.SubmitChanges();
            }
            else
            {
                _context.GioHangs.InsertOnSubmit(cart);
                _context.SubmitChanges();
            }
        }
        public void DeleteItemInCart(GioHang cart)
        {
            var existingCart = _context.GioHangs.SingleOrDefault(c => cart.maKH == c.maKH && cart.maCTSP == c.maCTSP);
            if (existingCart != null)
            {
                _context.GioHangs.DeleteOnSubmit(existingCart);
                _context.SubmitChanges();
            }
            else
            {
                _context.GioHangs.InsertOnSubmit(cart);
                _context.SubmitChanges();
            }
        }
        //public string GetLastCartCode()
        //{
        //    return _context.GioHangs
        //        .OrderByDescending(gh => gh.ma)
        //        .Select(kh => kh.maKH)
        //        .FirstOrDefault();
        //}
    }
}