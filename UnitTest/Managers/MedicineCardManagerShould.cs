using MedicineApi.Managers;
using MedicineApi.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Managers
{
    public class MedicineCardManagerShould
    {
        [Fact]
        public async void ThrowArgumentException_WhenCprIsNull_GetMedicineCardAsync()
        {
            // Arrange
            IMedicineCardManager manager = GetFakeManager();
            string cpr = null;

            // Act
            Func<Task> func = async () => await manager.GetMedicineCardAsync(cpr);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }

        [Fact]
        public async void ThrowArgumentException_WhenCprIsEmpty_GetMedicineCardAsync()
        {
            // Arrange
            IMedicineCardManager manager = GetFakeManager();
            string cpr = "";

            // Act
            Func<Task> func = async () => await manager.GetMedicineCardAsync(cpr);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }

        [Theory]
        [InlineData("1111111111")]
        [InlineData("111111-1111")]
        public async void GetResult_WhenCprIsValid_GetMedicineCardAsync(string cpr)
        {
            // Arrange
            IMedicineCardManager manager = GetFakeManager();
            MedicineCard card = null;

            // Act
            card = await manager.GetMedicineCardAsync(cpr);

            // Assert
            Assert.NotNull(card);
        }

        private IMedicineCardManager GetFakeManager()
        {
            return new FmkMedicineCardManagerMock();
        }
    }
}
