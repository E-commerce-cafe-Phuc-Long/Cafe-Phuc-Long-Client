using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce_Coffee_And_Tea_Client.ApiControllers
{
    [RoutePrefix("api/product")]
    public class APIProductController : ApiController
    {
        private readonly IProductService _productService;
        public APIProductController(IProductService productService)
        {
            _productService = productService;
        }
         //POST: api/product/get-products-list
        //[Route("get-products-list")]
        //[HttpGet]
        //public IHttpActionResult GetProductsList()
        //public List<SanPham> GetProductsList()
        //public string GetProductsList()
        //{
            //List<SanPham> products = _productService.GetProductList();
            //foreach (SanPham p in products)
            //{

            //}
            //var data = new
            //{
            //    maKH = "maKH",
            //    maCTSP = "maCTSP",
            //    soLuongDatHang = "soLuongDatHang",
            //    donGia = "donGia",
            //    thanhTien = "thanhTien",
            //    lieuLuongDa = "lieuLuongDa",
            //    lieuLuongNgot = "lieuLuongNgot",
            //    lieuLuongTra = "lieuLuongTra",
            //};
            
            //return Ok(new { success = true, message = "Thành công!", data });
            //return products;
        //}
        //public List<SanPham> GetProductsList()
        //{
        //    var products = _productService.GetProductList();
        //    //return Ok(products);
        //    //return Json(new { success = true, message = "Thành công!" });
        //    return products;
        //}
    }
}
