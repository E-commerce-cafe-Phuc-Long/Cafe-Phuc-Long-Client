using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Dosage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Dosage
{
    public class DosageService : IDosageService
    {
        private readonly IDosageRepository _repository;
        public DosageService(IDosageRepository repository)
        {
            this._repository = repository;
        }
        public List<LieuLuong> GetAll()
        {
            return _repository.GetAll();
        }
    }
}