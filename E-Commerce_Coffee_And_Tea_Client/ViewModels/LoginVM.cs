using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce_Coffee_And_Tea_Client.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username cannot be blank.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }
    }
}