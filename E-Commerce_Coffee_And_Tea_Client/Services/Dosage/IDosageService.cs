﻿using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Dosage
{
    public interface IDosageService
    {
        List<LieuLuong> GetAll();
    }
}
