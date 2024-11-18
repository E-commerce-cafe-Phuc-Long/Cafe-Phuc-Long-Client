using E_Commerce_Coffee_And_Tea_Client.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productService.GetProductList();
            return View(products);
        }
    }
}