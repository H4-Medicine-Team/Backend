using MedicineApi.Interfaces;
using MedicineApi.Models;
using MedicineApi.Models.UserLoginModels;
using MedicineApi.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace MedicineApi.Managers
{
    public class UserManager<TUser> : IUserManager<Person>
    {
        RngGenerator Rng;
       
        public UserManager()
        {
            Rng = new RngGenerator();
        }

        
        public Task<bool> AddLoginAsync(Person user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task GetCookie(Person user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTokenAsync(Person user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Person> IsLoggedAsync(Person user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetTokenAsync(Person user, string loginProvider, string name, string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
