using Xunit;
using Moq;
using Travel.BLL.Interfaces;
using Travel.BLL.Dtos.Trip;
using Travel.API.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TravelUnitTests
{
    public class TripsControllerTests
    {

        private readonly Mock<ITripService> serviceStub = new();

        [Fact]
        public async Task GetTripByID_WithNonExistingItem_ReturnsNotFound()
        {
            // Arrange
            serviceStub.Setup(serv => serv.GetTripByID(It.IsAny<int>()))
                .ReturnsAsync((GetTripDto)null);

            var controller = new TripsController(serviceStub.Object);
            // Act
            var result = await controller.GetTripByID(1000);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetTripByID_WithZeroOrNegativeItem_ReturnsBadRequest()
        {
            // Arrange
            serviceStub.Setup(serv => serv.GetTripByID(It.IsAny<int>()))
                .ReturnsAsync((GetTripDto)null);

            var controller = new TripsController(serviceStub.Object);
            // Act
            var result = await controller.GetTripByID(0);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        //[Fact]
        //public async Task GetTripByID_WithExistingItem_ReturnsExpectedItem()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

        //private GetTripDto CreateRandomTrip()
        //{
        //    return new()
        //    {

        //    }
        //}
    }
}