using MedicineApi.Data.Enums;
using MedicineApi.Models;
using MedicineApi.Models.UserLoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicineApi.Data.Interfaces
{
    /// <summary>
    /// Manager for the login role and tokens, generated where TUser Class.
    /// </summary>
    public interface IUserManager<TUser> where TUser : class
    {
        /// <summary>
        ///  Log in user & return boolean
        /// </summary>
        public Task<bool> LoginAsync(UserLogin user);
        /// <summary>
        /// Log in user with token returning boolean
        /// </summary>
        public Task<bool> LoginWithTokenAsync(Token userToken);
        /// <summary>
        ///  Setting valid token for login.
        /// </summary>
        public Task GenerateTokenAsync(TUser user);
        /// <summary>
        ///  Checks if token is still valid .
        /// </summary>
        public Task<bool> ValidateTokenAsync(Token user);
        /// <summary>
        /// Sets the user's role
        /// </summary>
        public Task<bool> SetRoleAsync(TUser user, Role role);
        /// <summary>
        /// Retrieve the user's role
        /// </summary>
        public Task<Role> GetRoleAsync(string userID);
        /// <summary>
        /// get user by ID
        /// </summary>
        public Task<TUser> GetUserByIDAsync(string userID);
        /// <summary>
        /// Get user by token
        /// </summary>
        public Task<TUser> GetUserWithTokenAsync(Token token);
    }
}
