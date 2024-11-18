using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }
        public SanPham GetProductById(string productId)
        {
            return _repository.GetProductById(productId);
        }
        public List<SanPham> GetProductByName(string productName)
        {
            return _repository.GetProductByName(productName);
        }
        public List<SanPham> GetProductList()
        {
            return _repository.GetProductList();
        }
    }
}