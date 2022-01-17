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
    /// <typeparam name="TUser"></typeparam>
    public interface IUserManager<TUser> where TUser : class
    {
        /// <summary>
        ///  Log in user & return boolean
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> LoginAsync(string username, string password);
        /// <summary>
        /// Log in user with token returning boolean
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<bool> LoginWithTokenAsync(string token);
        /// <summary>
        ///  Setting valid token for login.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task GenerateTokenAsync(TUser user);
        /// <summary>
        ///  Checks if token is still valid .
        /// </summary>
        /// <param name="login"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> ValidateTokenAsync(TUser user);
        /// <summary>
        /// Sets the user's role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> SetRoleAsync(TUser user, Role role);
        /// <summary>
        /// Retrieve the user's role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Role> GetRoleAsync(string userID);
        /// <summary>
        /// get user by ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Task<TUser> GetUserByIDAsync(string userID);
        /// <summary>
        /// Get user by token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<TUser> GetUserWithTokenAsync(string token);
    }
}
