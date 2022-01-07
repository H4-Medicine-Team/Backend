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

        [Theory]
        [InlineData(-10)]
        public async void ThrowBadRequestException_WhenRemoveDosageIDIsNotValid_RemoveReminderAsync(int dosageId)
        {
            // Arrange
            DosageController controller = GetFakeController();
            IActionResult result;

            // Act
            result = await controller.RemoveReminderAsync(dosageId);

            // Act && Assert
            Assert.NotNull(result as NullReferenceException);
        }

        [Theory]
        [InlineData(-10)]
        public async void ThrowBadRequestException_WhenInsertDosageIDIsNotValid_InsertReminderAsync(int dosageId)
        {
            // Arrange
            DosageController controller = GetFakeController();
            IActionResult result;

            // Act
            result = await controller.InsertReminderAsync(dosageId,new Dosage());

            // Act && Assert
            Assert.NotNull(result as DbUpdateException);
        }


        private DosageController GetFakeController()
        {
            IDosageManager manager = new DosageManager(,);
            ILogger<DosageController> logger = new NullLogger<DosageController>();

            return new DosageController(manager, logger);
        }
    }
}
