using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Coffee_And_Tea_Client.Controllers
{
    [RoutePrefix("profile")]
    public class CustomerController : Controller
    {
        [Route("")]
        public ActionResult GetInfo()
        {
            return View();
        }
    }
}