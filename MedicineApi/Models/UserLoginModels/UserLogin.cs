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
            set;
        }
        /// <summary>
        /// Password for the user
        /// </summary>
        public string Password
        {
            get;
            set;
        }


        public UserLogin()
        {
        }

        /// <summary>
        /// Creates a UserLogin from the given username and password
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
