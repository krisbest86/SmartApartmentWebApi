using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartApartmentApi.Controllers
{
    public class RealEstateDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}