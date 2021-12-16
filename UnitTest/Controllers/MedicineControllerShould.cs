using MedicineApi.Controllers;
using MedicineApi.Managers;
using MedicineApi.Models;
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
        public async void ThrowArgumentException_WhenCprNumberIsNull_GetMedicineCardAsync()
        {
            // Arrange
            string cpr = null;
            MedicineController controller = GetFakeController();

            // Act
            Func<Task> func = async () => await controller.GetMedicineCardAsync(cpr);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }

        [Fact]
        public async void ThrowArgumentException_WhenCprNumberIsEmpty_GetMedicineCardAsync()
        {
            // Arrange
            string cpr = "";
            MedicineController controller = GetFakeController();

            // Act
            Func<Task> func = async () => await controller.GetMedicineCardAsync(cpr);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }

        [Fact]
        public async void GetResult_WhenCprNumberIsNotEmpty_GetMedicineCardAsync()
        {
            // Arrange
            MedicineController controller = GetFakeController();
            string cpr = "1111";
            MedicineCard card = null;

            // Act
            card = await controller.GetMedicineCardAsync(cpr);

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
