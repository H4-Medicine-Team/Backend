using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.UserLoginModels
{
    public class Token
    {
        /// <summary>
        /// The user token 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Construct the usertoken class
        /// </summary>
        /// <param name="token">Token for the user</param>
        public Token(string token)
        {
            Key = token;
        }
    }
}
