using Microsoft.Extensions.Logging;
using MedicineApi.Models;
using MedicineApi.Managers;
using MedicineApi.Controllers;
using MedicineApi.Profiles;
using System;
using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;
using FakeItEasy;
using System.Threading.Tasks;

namespace UnitTest.Controllers
{
    public class DosageControllerShould
    {
        [Fact]
        public void ThrowArgumentNullException_WhenDosageManagerIsNull()
        {
            // Arrange
            ILogger<DosageController> logger = new NullLogger<DosageController>();

            // Act & Assert
            Assert.ThrowsAny<ArgumentNullException>(() => new DosageController(null, logger));
        }

        [Fact]
        public async void ThrowBadRequestException_WhenRemoveDosageIDIsNotValid_RemoveReminderAsync()
        {
            // Arrange
            DosageController controller = GetFakeController();
            int dosageId = -10;
            IActionResult expected;

            // Act
            expected = await controller.RemoveReminderAsync(dosageId);

            // Act && Assert
            Assert.NotNull(expected as BadRequestObjectResult);
        }

        [Fact]
        public async void ThrowBadRequestException_WhenInsertDosageIDIsNotValid_InsertReminderAsync()
        {
            // Arrange
            DosageController controller = GetFakeController();
            IActionResult result;
            int dosageId = -10;

            // Act
            result = await controller.InsertReminderAsync(dosageId, new Dosage());

            // Act && Assert
            Assert.NotNull(result as BadRequestObjectResult);
        }


        private DosageController GetFakeController()
        {
            IDosageManager manager = A.Fake<IDosageManager>();
            ILogger<DosageController> logger = new NullLogger<DosageController>();

            return new DosageController(manager, logger);
        }
    }
}
