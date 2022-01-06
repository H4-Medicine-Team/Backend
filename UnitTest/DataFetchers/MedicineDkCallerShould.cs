using MedicineApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MedicineApi;
using System.Net;
using MedicineApi.Models.MedicineDk;

namespace UnitTest.DataFetchers
{
    public class MedicineDkCallerShould
    {
        [Fact]
        public async void ThrowArgumentException_WhenDrugIdIsNotFound_GetMedicineByDrugId()
        {
            // Arrange
            IGetMedication<string> caller = GetFakeCaller();
            string drugID = "Does not exist";

            // Act
            Func<Task> func = async () => await caller.GetMedicineByDrugId(drugID);

            // Assert
            await Assert.ThrowsAnyAsync<WebException>(func);
        }
        [Fact]
        public async void ThrowArgumentException_WhenDliIsNotFound_GetMedicineByDrugId()
        {
            // Arrange
            IGetMedication<string> caller = GetFakeCaller();
            string dli = "Does not exist";

            // Act
            Func<Task> func = async () => await caller.GetMedicineByDrugId(dli);

            // Assert
            await Assert.ThrowsAnyAsync<WebException>(func);
        }

        [Fact]
        public async void ThrowArgumentException_WhenPackageIdIsNotFound_GetMedicineByDrugId()
        {
            // Arrange
            IGetMedication<string> caller = GetFakeCaller();
            string packageId = "Does not exist";
            // Act
            Func<Task> func = async () => await caller.GetMedicineByDrugId(packageId);

            // Assert
            await Assert.ThrowsAnyAsync<WebException>(func);
        }

        [Theory]
        [InlineData("1235")]
        [InlineData("1234")]
        public async void GetResult_WhenMedicineNameIsValid_GetMedicineCardAsync(string drugId)
        {
            // Arrange
            IGetMedication<string> manager = GetFakeCaller();

            // Act
            string getResult = await manager.GetMedicineByDrugId(drugId);

            // Assert
            Assert.NotNull(getResult);
        }


        public IGetMedication<string> GetFakeCaller()
        {
            return new MedicineDkCallerMock();
        }
    }
}
