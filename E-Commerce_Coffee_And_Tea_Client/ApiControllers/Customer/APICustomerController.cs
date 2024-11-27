using E_Commerce_Coffee_And_Tea_Client.Services.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce_Coffee_And_Tea_Client.ApiControllers
{
    [RoutePrefix("api/customer")]
    public class APICustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        public APICustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [Route("get-customer-by-username")]
        [HttpGet]
        public IHttpActionResult GetCustomerByUsername(string username)
        {
            var user = _customerService.GetCustomerByUsername(username);
            var data = new
            {
                maKH = user.maKH,
                tenKH = user.tenKH,
                email = user.email,
                soDT = user.soDT,
                diaChi = user.diaChi
            };
            return Ok(new { success = true, message = "Thành công!", data });
        }
    }
}
