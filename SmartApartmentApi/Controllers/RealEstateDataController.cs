using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestModel;

namespace SmartApartmentApi.Controllers
{
    public class RealEstateDataController : Controller
    {
        [HttpGet("/realEstate/:city/:guid")]
        [Authorize("read")]
        public IActionResult GetPropertyInformation(string city, Guid guid)
        {
            return Ok(city);
        }

        [HttpGet("/realEstate/:city")]
        [Authorize("read")]
        public IActionResult GetRealEstateData(string city, [FromBody] QueryDataRequest queryDataRequest)
        {
            return Ok(city);
        }

        [HttpPost("/realEstate/:city")]
        [Authorize("insert")]
        public IActionResult PostRealEstateData(string city, PropertyRequest propertyRequest)
        {
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated and have a scope of post to see this."
            });
        }
    }
}