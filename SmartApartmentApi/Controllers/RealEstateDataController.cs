using Abstraction;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestModel;
using System;

namespace SmartApartmentApi.Controllers
{
    public class RealEstateDataController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RealEstateDataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("/realEstate/:guid")]
        [Authorize("read")]
        public IActionResult GetPropertyInformation(Guid guid)
        {
            return StatusCode(200, _unitOfWork.Properties.GetById(guid));
        }

        [HttpGet("/realEstate/:city")]
        [Authorize("read")]
        public IActionResult GetRealEstateData(string city)
        {
            return StatusCode(200, _unitOfWork.Properties.GetCityRentalEstateData(city));
        }

        [HttpPost("/realEstate/:city")]
        [Authorize("insert")]
        public IActionResult PostRealEstateData(string city, PropertyRequest propertyRequest)
        {

            _unitOfWork.Properties.Add(new Property()
            {
                City = propertyRequest.City,

            });

            return StatusCode(200, _unitOfWork.Complete());
        }
    }
}