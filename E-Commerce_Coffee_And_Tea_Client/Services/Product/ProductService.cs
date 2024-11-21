using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories;
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
        public List<ChiTietSanPham> GetProductByName(string productName)
        {
            return _repository.GetProductByName(productName);
        }
        public List<SanPham> GetProductList()
        {
            return _repository.GetProductList();
        }
        public List<ChiTietSanPham> GetLastProductDetailByIds(List<string> productIds)
        {
            return _repository.GetLastProductDetailByIds(productIds);
        }
        public ChiTietSanPham GetProductDetailByIdAndSizeId(string productId, string sizeId)
        {
            return _repository.GetProductDetailByIdAndSizeId(productId, sizeId);
        }
        public List<SanPham> GetProductByCategoryId(string categoryId)
        {
            return _repository.GetProductByCategoryId(categoryId);
        }
    }
}