using Abstraction;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RequestModel;
using ResponseModel;
using SmartApartmentApi.Controllers;
using System;
using UnitsOfWork.DataAccessImplementations;
using Xunit;

namespace SmartApartmentUnitTests.Controllers
{
    public class RealEstateControllerTests
    {
        private readonly RealEstateDataController _realEstateDataController;

        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        public RealEstateControllerTests()
        {
            _realEstateDataController = new RealEstateDataController(_unitOfWorkMock.Object);
        }

        [Fact]
        public void GetPropertyInformation_ValidGuid_ReturnStatusCode200()
        {

            // Arrange
            var guid = Guid.NewGuid();
            _unitOfWorkMock.Setup(a => a.Properties.GetById(guid)).Returns(new Property());

            // Act
            var response = _realEstateDataController.GetPropertyInformation(guid);

            // Assert
            Assert.IsType<ObjectResult>(response);
            var objectResponse = response as ObjectResult;

            Assert.Equal(200, objectResponse?.StatusCode);
        }


        [Fact]
        public void GetPropertyInformation_InValidGuid_ReturnStatusCode404()
        {
            // Arrange
            var guid = Guid.NewGuid();
            _unitOfWorkMock.Setup(a => a.Properties.GetById(guid)).Returns<Property>(null);

            // Act
            var response = _realEstateDataController.GetPropertyInformation(guid);

            // Assert
            Assert.IsType<ObjectResult>(response);
            var objectResponse = response as ObjectResult;

            Assert.Equal(404, objectResponse?.StatusCode);
        }


        [Fact]
        public void GetRealEstateData_ValidCity_ReturnStatusCode200()
        {
            // Arrange
            var city = "Austin";
            _unitOfWorkMock.Setup(a => a.Properties.GetCityRentalEstateData(city)).Returns(new CityRentalEstateData());

            // Act
            var response = _realEstateDataController.GetRealEstateData(city);

            // Assert
            Assert.IsType<ObjectResult>(response);
            var objectResponse = response as ObjectResult;

            Assert.Equal(200, objectResponse?.StatusCode);
        }


        [Fact]
        public void GetRealEstateData_InValidCity_ReturnStatusCode404()
        {
            // Arrange
            var city = "Austin";
            _unitOfWorkMock.Setup(a => a.Properties.GetCityRentalEstateData(city)).Returns<CityRentalEstateData>(null);

            // Act
            var response = _realEstateDataController.GetRealEstateData(city);

            // Assert
            Assert.IsType<ObjectResult>(response);
            var objectResponse = response as ObjectResult;

            Assert.Equal(404, objectResponse?.StatusCode);
        }



        [Fact]
        public void PostRealEstateData_ValidRequest_ReturnStatusCode200()
        {
            _unitOfWorkMock.Setup(a => a.Properties).Returns(new PropertyDataAccess(new SmartApartmentContext()));

            // Act
            var response = _realEstateDataController.PostRealEstateData(new PropertyRequest()
            {
                City = "City",
                Name = "Name",
                Price = 123
            });

            // Assert
            Assert.IsType<ObjectResult>(response);
            var objectResponse = response as ObjectResult;

            Assert.Equal(200, objectResponse?.StatusCode);
        }


        [Fact]
        public void PostRealEstateData_NullRequest_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _realEstateDataController.PostRealEstateData(null));
        }
    }
}
