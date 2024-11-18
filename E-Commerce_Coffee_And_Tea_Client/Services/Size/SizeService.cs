using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Size
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _repository;
        public SizeService(ISizeRepository sizeRepository)
        {
            this._repository = sizeRepository;
        }
        public List<DataAccess.Size> GetAll()
        {
            return _repository.GetAll();
        }
        public List<DataAccess.Size> GetSizesByProductId(string productId)
        {
            return _repository.GetSizesByProductId(productId);
        }
    }
}