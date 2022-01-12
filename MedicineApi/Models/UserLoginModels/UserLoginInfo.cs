using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models.UserLoginModels
{
    public class UserLoginInfo
    {
        /// <summary>
        ///The provider associated with this login information.
        /// </summary>
        public string LoginProvider { get; private set; }
        /// <summary>
        /// The unique identifier for this user provided by the login provider.
        /// </summary>
        public string ProviderKey { get; private set; }
        /// <summary>
        /// The display name for this user provided by the login provider.
        /// </summary>
        public string DisplayName { get; private set; }

        public UserLoginInfo(string loginProvider, string providerKey, string displayName)
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
            DisplayName = displayName;
        }
    }
}
