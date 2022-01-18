using MedicineApi.Data.Enums;
using MedicineApi.Data.Interfaces;
using MedicineApi.Models;
using MedicineApi.Models.UserLoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;


namespace MedicineApi.Managers
{
    public class UserManager<TUser> : IUserManager<UserLoginInfo>
    {
        //Mocket user
        List<UserLoginInfo> MockUser = new List<UserLoginInfo>();

        /// <summary>
        /// creating a list of userlogins for mocking
        /// </summary>
        public UserManager()
        {
            //Mock Data
            MockUser.Add(new UserLoginInfo(new UserLogin("12345678910", "key"), new Token("mZaFi4DW2Ujh921niAwzSqKKtgzYsXvR"), Role.User));
        }

        /// <inheritdoc />
        public Task<bool> LoginAsync(UserLogin user)
        {
            //Checking if user exsist by given username & password then return true
            if (MockUser.FirstOrDefault(o => o.Username == user.Username && o.Password == user.Password) is UserLoginInfo tempUser && tempUser != null)
                return Task.Run(() => { return true; });

            //return false if not found
            return Task.Run(() => { return false; });
        }
        /// <inheritdoc />
        public Task<bool> LoginWithTokenAsync(Token userToken)
        {
            //Checking if user exsist by given username & password then return true
            if (MockUser.FirstOrDefault(o => o.UserToken.Key == userToken.Key) is UserLoginInfo tempUser && tempUser != null)
                return Task.Run(() => { return true; });
            //return false if not found
            return Task.Run(() => { return false; });
        }
        /// <inheritdoc />
        public Task GenerateTokenAsync(UserLoginInfo user)
        {
            try
            {
                //Creating timestamp into byte[]
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                //Generate unique Token
                byte[] key = Guid.NewGuid().ToByteArray();
                //Creating token with timestamp (this token is not secure, and easy to fake, later need encryption to secure token)
                var Token = Convert.ToBase64String(time.Concat(key).ToArray());
                //setting user token
                user.UserToken = new Token(Token);
                //returning taks completed
                return Task.Run(() => Task.CompletedTask);
            }
            catch (Exception ex)
            {
                //Throwing found exception
                throw new Exception($"Generatetoken : {ex.Message}");
            }
        }
        /// <inheritdoc />
        public Task<bool> ValidateTokenAsync(Token token)
        {
            try
            {
                //Check if user token is not null
                if (token == null)
                    throw new ArgumentNullException("User", new Exception("User not found"));
                //Check if token is empty or null
                if (string.IsNullOrEmpty(token.Key))
                    throw new Exception("Token is not set");
                //Converting token to bytearray
                byte[] data = Convert.FromBase64String(token.Key);
                //Converting the binary bytearray to datetime
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                //Checking if token is expired if true then return false (token is not valid)
                if (when < DateTime.UtcNow.AddHours(-24))
                    return Task.Run(() => { return false; });
                //return true if token is valid
                return Task.Run(() => { return true; });

            }
            catch (Exception ex)
            {
                //throwing exception
                throw new Exception($"Validating token : {ex.Message}");
            }
        }
        /// <inheritdoc />
        public Task<bool> SetRoleAsync(UserLoginInfo user, Role role)
        {
            try
            {
                //setting the user role
                user.Role = role;
                //returning true if set
                return Task.Run(() => { return true; });
            }
            catch (Exception ex)
            {
                //if exeception happen return error
                throw new Exception($"SetRole : {ex.Message}");
            }
        }

        /// <inheritdoc />
        public Task<Role> GetRoleAsync(string userID)
        {
            //Checking if parse variable is empty or null
            if (string.IsNullOrEmpty(userID))
                throw new ArgumentNullException("GetRole", new Exception("UserID is null or empty"));
            //checking if user exist & then return user role
            if ( MockUser.FirstOrDefault(o => o.Username == userID) is UserLoginInfo user && user != null)
                return Task.Run(() => { return user.Role; });
            else
                throw new Exception("No user found");
        }


       
        /// <inheritdoc />
        public Task<UserLoginInfo> GetUserByIDAsync(string userID)
        {
            //finding user by ID, if found return matching user
            if (MockUser.FirstOrDefault(o => o.Username == userID) is UserLoginInfo tempUser && tempUser != null)
                return Task.Run(() => { return tempUser; });
            //else throw execption
            throw new Exception("User not found");
        }
        /// <inheritdoc />
        public Task<UserLoginInfo> GetUserWithTokenAsync(Token token)
        {
            //Finding user by Token, if found return matching user
            if (MockUser.FirstOrDefault(o => o.UserToken.Key == token.Key) is UserLoginInfo tempUser && tempUser != null)
                return Task.Run(() => { return tempUser; });
            //throw execption if not found
            throw new Exception("User not found");
        }
       

    }

}
