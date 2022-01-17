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
        public void ThrowArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            IDosageManager manager = A.Fake<IDosageManager>();

            // Act & Assert
            Assert.ThrowsAny<ArgumentNullException>(() => new DosageController(manager, null));
        }

        [Fact]
        public async void ThrowBadRequestException_WhenGetUserIdIsOutOfRange_GetLatesReminderAsync()
        {
            // Arrange
            DosageController controller = GetFakeController();
            int userid = -10;
            IActionResult expected;

            // Act
            expected = await controller.GetLatesReminderAsync(userid);

            // Act && Assert
            Assert.NotNull(expected as BadRequestObjectResult);
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
            Dosage dosage = new Dosage();
            int userid = 1;

            // Act
            result = await controller.InsertReminderAsync(dosageId, dosage, userid);

            // Act && Assert
            Assert.NotNull(result as BadRequestObjectResult);
        }

        [Fact]
        public async void ThrowBadRequestException_WhenEditDosageIsNull_EditReminderAsync()
        {
            // Arrange
            DosageController controller = GetFakeController();
            IActionResult result;

            // Act
            result = await controller.EditReminderAsync(null);

            // Act && Assert
            Assert.NotNull(result as BadRequestObjectResult);
        }

        [Fact]
        public async void ThrowBadRequestException_WhenEditDosagIntervalIsNull_EditReminderAsync()
        {
            // Arrange
            DosageController controller = GetFakeController();
            IActionResult result;
            Dosage dosage = new Dosage(10, AmountType.MG, null);

            // Act
            result = await controller.EditReminderAsync(dosage);

            // Act && Assert
            Assert.NotNull(result as BadRequestObjectResult);
        }

        [Fact]
        public async void ThrowBadRequestException_WhenEidtDosageAmmountIsOutOfRange_EditReminderAsync()
        {
            // Arrange
            DosageController controller = GetFakeController();
            IActionResult result;
            DayOfWeek[] dayOfWeek = new DayOfWeek[3] { DayOfWeek.Sunday,DayOfWeek.Saturday,DayOfWeek.Monday};
            Interval interval = new Interval(DateTime.Now, DateTime.Now.AddMinutes(5), DateTime.Now.AddHours(2), dayOfWeek);
            Dosage dosage = new Dosage(-5, AmountType.MG,interval);

            // Act
            result = await controller.EditReminderAsync(dosage);

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
