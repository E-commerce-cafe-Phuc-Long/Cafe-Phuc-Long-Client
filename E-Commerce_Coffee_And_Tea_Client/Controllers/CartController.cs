﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult _PartialPage_Cart()
        {
            return View();
        }
    }
}