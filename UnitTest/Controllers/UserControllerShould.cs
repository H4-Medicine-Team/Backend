using MedicineApi.Controllers;
using MedicineApi.Data.Interfaces;
using MedicineApi.Managers;
using MedicineApi.Models;
using MedicineApi.Models.UserLoginModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MedicineApi.Data.Enums;

namespace UnitTest.Controllers
{
    
    public class UserControllerShould
    {

        [Fact]
        public void ThrowArgumentNullException_WhenLoginManagerIsNull()
        {
            // Arrange
            ILogger<UserController> logger = new NullLogger<UserController>();

            // Act & Assert
            Assert.ThrowsAny<ArgumentNullException>(() => new UserController(null, logger));
        }

        [Fact]
        public void ThrowArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            IUserManager<UserLoginInfo> manager = new UserManager<UserLoginInfo>();

            // Act & Assert
            Assert.ThrowsAny<ArgumentNullException>(() => new UserController(manager, null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowBadRequestException_InvalidToken_Login(string token)
        {
            // Arrange
            UserController controller = GetFakeController();
            var user = new UserLoginInfo(token);
            // Act
            ActionResult<string> result = await controller.LoginWithTokenAsync(user);

         
            // Act && Assert
            Assert.NotNull(result.Result as BadRequestResult);
        }

        [Theory]
        [InlineData("hellomumu")]
        public async void ThrowBadRequestException_WithWrongTokenLogin(string token)
        {
            // Arrange
            UserController controller = GetFakeController();
            var user = new UserLoginInfo(token);
            // Act
            ActionResult<string> result = await controller.LoginWithTokenAsync(user);


            // Act && Assert
            Assert.NotNull(result.Result as NotFoundResult);
        }


        [Theory]
        [InlineData("","")]
        [InlineData(null, null)]
        public async void ThrowBadRequestException_InvalidLoginInfo_Login(string username, string password)
        {
            // Arrange
            UserController controller = GetFakeController();

            // Act
            var user = new UserLoginInfo(username, password);
            ActionResult<string> result = await controller.LoginAsync(user);

            // Act && Assert
            Assert.NotNull(result.Result as BadRequestObjectResult);
        }

        [Theory]
        [InlineData("bent", "")]
        [InlineData("bent", null)]
        public async void ThrowBadRequestException_WrongInfoGiven_Login(string username, string password)
        {
            // Arrange
            UserController controller = GetFakeController();

            // Act
            var user = new UserLoginInfo(username, password);
            ActionResult<string> result = await controller.LoginAsync(user);

            // Act && Assert
            Assert.NotNull(result.Result as BadRequestObjectResult);
        }

        [Theory]
        [InlineData("Molester", "Myangus")]
        [InlineData("Dig", "Brick")]
        public async void ThrowBadRequestException_WrongLoginCredentials_Login(string username, string password)
        {
            // Arrange
            UserController controller = GetFakeController();

            // Act
            var user = new UserLoginInfo(username, password);
            ActionResult<string> result = await controller.LoginAsync(user);

            // Act && Assert
            Assert.NotNull(result.Result as BadRequestResult);
        }


        [Theory]
        [InlineData("", Role.Guardian)]
        [InlineData(null, Role.Guardian)]
        public async void ThrowBadRequestException_InvalidUserIDRole_SetRole(string userid, Role role)
        {
            // Arrange
            UserController controller = GetFakeController();

            // Act
            ActionResult<bool> result = await controller.SetRoleAsync(userid, role);

            // Act && Assert
            Assert.NotNull(result.Result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowBadRequestException_InvalidSetUserID_GetRole(string userid)
        {
            // Arrange
            UserController controller = GetFakeController();

            // Act
            ActionResult<Role> result = await controller.GetRoleAsync(userid);

            // Act && Assert
            Assert.NotNull(result.Result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowArgumentExecption_WhenUserLoginInfoIsNull_LoginAsync(string userid)
        {
            
            //arrange
            UserController controller = GetFakeController();
            ActionResult<string> result;
            //Act

            result = await controller.LoginAsync(new UserLoginInfo(userid));
            //Assert
            Assert.NotNull(result.Result as BadRequestObjectResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async void ThrowArgumentExecption_WhenValidateTokenWithNullOrEmpty_Token(string userid)
        {

            //arrange
            UserController controller = GetFakeController();
            ActionResult<bool> result;
            //Act

            result = await controller.ValidateTokenAsync(userid);
            //Assert
            Assert.NotNull(result.Result as BadRequestObjectResult);
        }


        [Theory]
        [InlineData("123")]
        public async void ThrowArgumentExecption_WhenValidatingWithWrongCredential_Token(string userid)
        {

            //arrange
            UserController controller = GetFakeController();
            ActionResult<bool> result;
            //Act

            result = await controller.ValidateTokenAsync(userid);
            //Assert
            Assert.NotNull(result.Result as UnauthorizedResult);
        }



        private UserController GetFakeController()
        {
            IUserManager<UserLoginInfo> manager = new UserManager<UserLoginInfo>();
            ILogger<UserController> logger = new NullLogger<UserController>();
            return new UserController(manager, logger);
        }
    }
}
