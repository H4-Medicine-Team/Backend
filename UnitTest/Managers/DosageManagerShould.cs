using FakeItEasy;
using MedicineApi.Managers;
using System;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using MedicineApi.Models;

namespace UnitTest.Managers
{
    public class DosageManagerShould
    {
        [Fact]
        public async void ThrowArgumentOutOfException_WhenDosageIdIsOutOfRange_RemoveReminderAsync()
        {
            // Arrange
            IDosageManager manager = GetFakeManager();
            int dosageid = -10;

            // Act
            Func<Task> func = async () => await manager.RemoveReminderAsync(dosageid);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(func);
        }

        [Fact]
        public async void ThrowArgumentOutOfRangeException_WhenDrugIdIsOutOfRange_InsertReminderAsync()
        {
            // Arrange
            IDosageManager manager = GetFakeManager();
            int drugId = -10;
            Dosage dosage = new Dosage();

            // Act
            Func<Task> func = async () => await manager.InsertReminderAsync(drugId,dosage);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(func);
        }

        [Fact]
        public async void ThrowArgumentNullException_WhenDosageIsNull_InsertReminderAsync()
        {
            // Arrange
            IDosageManager manager = GetFakeManager();
            int drugId = 3;
            Dosage dosage = null;

            // Act
            Func<Task> func = async () => await manager.InsertReminderAsync(drugId,dosage);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async void ThrowArgumentNullException_WhenDosageIsNull_EditReminderAsync()
        {
            // Arrange
            IDosageManager manager = GetFakeManager();
            Dosage dosage = null;

            // Act
            Func<Task> func = async () => await manager.EditReminderAsync(dosage);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async void ThrowArgumentNullException_WhenIntervalIsNull_EditReminderAsync()
        {
            // Arrange
            IDosageManager manager = GetFakeManager();
            Dosage dosage = new Dosage(10,AmountType.MG,null);

            // Act
            Func<Task> func = async () => await manager.EditReminderAsync(dosage);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async void ThrowArgumentOutOfRangeException_WhenAmmountIsOutOfRange_EditReminderAsync()
        {
            // Arrange
            IDosageManager manager = GetFakeManager();
            Dosage dosage = new Dosage(-10, AmountType.MG, new Interval());

            // Act
            Func<Task> func = async () => await manager.EditReminderAsync(dosage);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(func);
        }

        private IDosageManager GetFakeManager()
        {
            using DataAccess.Dtos.MedicineContext medicineContext = new DataAccess.Dtos.MedicineContext();
            IMapper mapper = A.Fake<IMapper>();
            return new DosageManager(medicineContext,mapper);
        }
    }
}
