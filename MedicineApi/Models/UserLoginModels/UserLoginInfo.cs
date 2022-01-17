using MedicineApi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.UserLoginModels
{
    /// <summary>
    /// Class for login informations
    /// </summary>
    public class UserLoginInfo
    {
        /// <summary>
        ///The username associated with this login information.
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// The unique key/pass for login
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// The Token for user provided by the UserManager.
        /// </summary>
        public Token  UserToken { get;  set; }
        /// <summary>
        /// Get and setter for the user role 
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// Constructor for UserLoginInformation
        /// </summary>
        public UserLoginInfo(UserLogin user, Token token, Role role)
        {
            Username = user.Username;
            Password = user.Password;
            UserToken = token;
            Role = role;
        }

        public UserLoginInfo(UserLogin user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
        }

        public UserLoginInfo(Token token)
        {
            this.UserToken = token;
        }
    }
}
