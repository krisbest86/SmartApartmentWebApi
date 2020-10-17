using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartApartmentApi.Controllers
{
    public class RealEstateDataController : Controller
    {
        [HttpGet("/realEstate/city")]
        [Authorize("read")]
        public IActionResult GetRealEstateData()
        {
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated and have a scope of read to see this."
            });
        }

        [HttpPost("private-scoped")]
        [Authorize("insert")]
        public IActionResult PostRealEstateData()
        {
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated and have a scope of post to see this."
            });
        }
    }
}