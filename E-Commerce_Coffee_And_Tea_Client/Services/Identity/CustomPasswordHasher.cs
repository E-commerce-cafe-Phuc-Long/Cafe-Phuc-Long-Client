﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.Services.Identity
{
    public class CustomPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();

            // Chuyển đổi mật khẩu thành mảng byte (dạng mã hóa UTF-8)
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Băm mật khẩu (sử dụng SHA-256)
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Chuyển mảng byte kết quả thành chuỗi Base64 và trả về
            return Convert.ToBase64String(hashBytes);
        }
        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword) 
        {
            string hashOfProvidedPassword = HashPassword(providedPassword);
            if (hashOfProvidedPassword == hashedPassword)
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}