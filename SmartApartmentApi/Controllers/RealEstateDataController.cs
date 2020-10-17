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

            var result = _unitOfWork.Properties.GetById(guid);

            return result == null ? StatusCode(404, $"Data for {guid} not found") : StatusCode(200, result);
        }

        [HttpGet("/realEstate/:city")]
        [Authorize("read")]
        public IActionResult GetRealEstateData(string city)
        {
            var result = _unitOfWork.Properties.GetCityRentalEstateData(city);

            return result == null ? StatusCode(404, $"Data for {city} not found") : StatusCode(200, result);
        }

        [HttpPost("/realEstate/:city")]
        [Authorize("insert")]
        public IActionResult PostRealEstateData(PropertyRequest propertyRequest)
        {
            if (propertyRequest == null)
            {
                throw new ArgumentNullException(nameof(propertyRequest));
            }

            _unitOfWork.Properties.Add(new Property()
            {
                City = propertyRequest.City,
                Name = propertyRequest.Name,
                Price = propertyRequest.Price
            });

            return StatusCode(200, _unitOfWork.Complete());
        }
    }
}