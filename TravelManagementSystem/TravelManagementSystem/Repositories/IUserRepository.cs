using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
   public  interface IUserRepository
    {
        // get user details by using username and password
        public Users validateUser(string username, string password);
    }
}
