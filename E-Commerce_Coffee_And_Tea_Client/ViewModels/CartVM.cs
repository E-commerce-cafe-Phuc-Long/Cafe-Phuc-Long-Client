using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.ViewModels
{
    public class CartVM
    {
        public string MaKH { get; set; }
        public string MaCTSP { get; set; }
        public int SoLuongDatHang { get; set; }
        public decimal DonGia { get; set; } 
        public decimal? ThanhTien { get; set; }
        public string LieuLuongDa { get; set; }
        public string LieuLuongNgot { get; set; }
        public string LieuLuongTra { get; set; }

    }
}