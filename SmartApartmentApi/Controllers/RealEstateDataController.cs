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


        [HttpGet("/realEstate/property/{guid}")]
        [Authorize("read")]
        public IActionResult GetPropertyInformation(Guid guid)
        {
            var result = _unitOfWork.Properties.GetById(guid);

            return result == null ? StatusCode(404, $"Data for {guid} not found") : StatusCode(200, result);
        }

        [HttpGet("/realEstate/{city}")]
        [Authorize("read")]
        public IActionResult GetRealEstateData(string city)
        {
            var result = _unitOfWork.Properties.GetCityRentalEstateData(city);

            return result == null ? StatusCode(404, $"Data for {city} not found") : StatusCode(200, result);
        }

        [HttpPost("/realEstate")]
        [Authorize("insert")]
        public IActionResult PostRealEstateData([FromBody] PropertyRequest propertyRequest)
        {
            if (propertyRequest == null)
            {
                throw new ArgumentNullException(nameof(propertyRequest));
            }

            var property = new Property()
            {
                City = propertyRequest.City,
                Name = propertyRequest.Name,
                Price = propertyRequest.Price
            };
            _unitOfWork.Properties.Add(property);
            _unitOfWork.Complete();

            return StatusCode(200, property);
        }
    }
}