using Abstraction;
using Moq;
using SmartApartmentApi.Controllers;
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
        public void Test1()
        {

        }
    }
}
