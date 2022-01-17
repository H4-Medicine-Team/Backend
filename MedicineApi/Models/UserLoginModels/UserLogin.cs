using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.UserLoginModels
{
    public class UserLogin
    {
        /// <summary>
        /// Username of the user
        /// </summary>
        public string Username
        {
            get;
            private set;
        }
        /// <summary>
        /// Password for the user
        /// </summary>
        public string Password
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Username for the user</param>
        /// <param name="password">Password for the user</param>
        public UserLogin(string user, string password)
        {
            Username = user;
            Password = password;
        }
    }
}
