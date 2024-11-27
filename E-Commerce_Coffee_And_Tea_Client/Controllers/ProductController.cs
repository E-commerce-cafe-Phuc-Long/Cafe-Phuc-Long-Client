using E_Commerce_Coffee_And_Tea_Client.Services.Dosage;
using E_Commerce_Coffee_And_Tea_Client.Services.Product;
using E_Commerce_Coffee_And_Tea_Client.Services.Size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;
        private readonly IDosageService _dosageService;
        public ProductController(
            IProductService productService,
            ISizeService sizeService,
            IDosageService dosageService
            )
        {
            this._productService = productService;
            this._sizeService = sizeService;
            this._dosageService = dosageService;
        }

        // Route: /product
        [Route("")]
        public ActionResult Index()
        {
            List<string> productIds = new List<string>();

            var products = _productService.GetProductList();

            foreach (var product in products)
            {
                productIds.Add(product.maSP);
            }

            var productDetailList = _productService.GetLastProductDetailByIds(productIds);

            return View(productDetailList);
        }
        // Route: /product/detail/sp001/s001
        [Route("detail/{productId}/{sizeId}")]
        public ActionResult ProductDetail(string productId, string sizeId)
        {
            var details = _productService.GetProductDetailByIdAndSizeId(productId, sizeId);

            ViewBag.sizes = _sizeService.GetSizesByProductId(productId);

            ViewBag.dosages = _dosageService.GetAll();

            List<string> CategoriesHasTeaDosage = new List<string> { "DM001", "DM002" };
            ViewBag.categoriesHasTeaDosage = CategoriesHasTeaDosage;

            return View(details);
        }
        [Route("search")]
        public ActionResult SearchProduct(string productName)
        {
            var products = _productService.GetProductByName(productName);
            return View(products);
        }
    }
}