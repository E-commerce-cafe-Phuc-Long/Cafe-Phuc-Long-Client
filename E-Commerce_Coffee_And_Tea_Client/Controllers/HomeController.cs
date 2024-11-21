using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Category;
using E_Commerce_Coffee_And_Tea_Client.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public HomeController(
            IProductService productService,
            ICategoryService categoryService
            )
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {

            var categories = _categoryService.GetCategoriesList().Take(3);

            // Khởi tạo dictionary để nhóm các sản phẩm theo danh mục
            var productsByCategory = new Dictionary<string, List<ChiTietSanPham>>();

            foreach ( var category in categories )
            {
                var products = _productService.GetProductByCategoryId(category.maDM);

                // Lưu các mã sản phẩm theo danh mục
                List<string> productIds = new List<string>();

                foreach (var product in products)
                {
                    productIds.Add(product.maSP);
                }

                // Lấy chi tiết cuối của sản phẩm theo danh mục
                var productDetailList = _productService.GetLastProductDetailByIds(productIds);

                productsByCategory[category.tenDM] = productDetailList;
            }

            return View(productsByCategory);
        }
    }
}