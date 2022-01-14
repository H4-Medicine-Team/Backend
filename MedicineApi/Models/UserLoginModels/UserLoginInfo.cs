﻿using MedicineApi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.UserLoginModels
{
    public class UserLoginInfo
    {
        /// <summary>
        ///The username associated with this login information.
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// The unique key/pass for login
        /// </summary>
        public string ProviderKey { get; private set; }
        /// <summary>
        /// The Token for user provided by the UserManager.
        /// </summary>
        public string Token { get;  set; }
        /// <summary>
        /// Get and setter for the user role 
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// Constructor for UserLoginInformation
        /// </summary>
        /// <param name="username"></param>
        /// <param name="providerKey"></param>
        /// <param name="token"></param>
        /// <param name="role"></param>
        public UserLoginInfo(string username, string providerKey, string token, Role role)
        {
            Username = username;
            ProviderKey = providerKey;
            Token = token;
            Role = role;
        }
    }
}