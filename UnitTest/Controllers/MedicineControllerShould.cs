using MedicineApi.Controllers;
using MedicineApi.Managers;
using MedicineApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Controllers
{
    public class MedicineControllerShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenMedicineManagerIsNull()
        {
            // Arrange
            ILogger<MedicineController> logger = new NullLogger<MedicineController>();

            // Act & Assert
            Assert.ThrowsAny<ArgumentNullException>(() => new MedicineController(null, logger));
        }

        [Fact]
        public void ThrowArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            IMedicineCardManager manager = new FmkMedicineCardManagerMock();

            // Act & Assert
            Assert.ThrowsAny<ArgumentNullException>(() => new MedicineController(manager, null));
        }

        [Fact]
        public async void ThrowBadRequestException_WhenCprNumberIsNull_GetMedicineCardAsync()
        {
            // Arrange
            string cpr = null;
            MedicineController controller = GetFakeController();
            ActionResult<MedicineCard> result;

            // Act
            result = await controller.GetMedicineCardAsync(cpr);

            // Act && Assert
            Assert.NotNull(result.Result as BadRequestObjectResult);
        }

        [Fact]
        public async void ThrowBadRequestException_WhenCprNumberIsEmpty_GetMedicineCardAsync()
        {
            // Arrange
            string cpr = "";
            MedicineController controller = GetFakeController();
            ActionResult<MedicineCard> result;

            // Act
            result = await controller.GetMedicineCardAsync(cpr);

            // Act && Assert
            Assert.NotNull(result.Result as BadRequestObjectResult);
        }

        [Theory]
        [InlineData("1111111111")]
        [InlineData("111111-1111")]
        public async void GetResult_WhenCprNumberIsNotEmpty_GetMedicineCardAsync(string cpr)
        {
            // Arrange
            MedicineController controller = GetFakeController();
            MedicineCard card = null;

            // Act
            card = (await controller.GetMedicineCardAsync(cpr)).Value;

            // Assert
            Assert.NotNull(card);
        }

        private MedicineController GetFakeController()
        {
            IMedicineCardManager manager = new FmkMedicineCardManagerMock();
            ILogger<MedicineController> logger = new NullLogger<MedicineController>();

            return new MedicineController(manager, logger);
        }

    }
}
