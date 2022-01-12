using MedicineApi.Models;
using MedicineApi.Models.UserLoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicineApi.Interfaces
{
    interface IUserManager<TUser> where TUser : class 
    {
        public Task<string> GetTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken);

        public Task SetTokenAsync(TUser user, string loginProvider, string name, string value, CancellationToken cancellationToken);

        public Task<bool> AddLoginAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken);

        public Task<Person> IsLoggedAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken);

       
    }
}
