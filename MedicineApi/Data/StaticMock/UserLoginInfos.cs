using MedicineApi.Models.UserLoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Data.StaticMock
{
    public class UserLoginInfos<TUser>
    {
        //Mock list for UserLoginInfo
        public static List<TUser> users = new List<TUser>();
    }
}
