using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace SmartApartmentApi.Controllers
{
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("/auth/token")]
        public IActionResult GetToken()
        {
            var result = _authService.GetToken();
            return StatusCode(200, result);
        }
    }
}