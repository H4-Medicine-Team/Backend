using MedicineApi.Managers;
using MedicineApi.Models.MedicineDk;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Managers
{
    public class MedicineDkManagerShould
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowArgumentException_WhenDrugIdIsNullOrEmpty_GetMedicineByDrugId(string drugID)
        {
            // Arrange
            IMedicineDkManager manager = GetFakeManager();        

            // Act
            Func<Task> func = async () => await manager.GetMedicineByDrugId(drugID);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowArgumentException_WhenDliIsNullOrEmpty_GetMedicineByIdentifier(string dli)
        {
            // Arrange
            IMedicineDkManager manager = GetFakeManager();

            // Act
            Func<Task> func = async () => await manager.GetMedicineByIdentifier(dli);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowArgumentException_WhenPackageIdIsNullOrEmpty_GetMedicineByPackageNumberId(string packageID)
        {
            // Arrange
            IMedicineDkManager manager = GetFakeManager();

            // Act
            Func<Task> func = async () => await manager.GetMedicineByPackageNumberId(packageID);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowArgumentException_WhenMedicineNameIsNullOrEmpty_SearchMedicineByDrugName(string medicineName)
        {
            // Arrange
            IMedicineDkManager manager = GetFakeManager();

            // Act
            Func<Task> func = async () => await manager.SearchMedicineByDrugName(medicineName);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(func);
        }

        [Theory]
        [InlineData("para")]
        [InlineData("paracentanol")]
        public async void GetResult_WhenMedicineNameIsValid_GetMedicineCardAsync(string medicineName)
        {
            // Arrange
            IMedicineDkManager manager = GetFakeManager();
            SearchResult searchResult = null;

            // Act
            searchResult = await manager.SearchMedicineByDrugName(medicineName);

            // Assert
            Assert.NotNull(searchResult);
        }

        [Fact]
        public async void GetResult_WhenGetMedicinByIdentifierIsValid_GetMedicineCardAsync()
        {
            // Arrange
            IMedicineDkManager manager = GetFakeManager();
            GetResult getResult = null;
            string drugIdentifier = "4810";

            // Act
            getResult = await manager.GetMedicineByIdentifier(drugIdentifier);
            
            // Assert
            Assert.NotNull(getResult);
        }


        private IMedicineDkManager GetFakeManager()
        {
            return new MedicineDkManagerMock();
        }
    }
}
