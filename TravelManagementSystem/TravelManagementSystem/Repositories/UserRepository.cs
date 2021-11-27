using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
    public class UserRepository:IUserRepository
    {
        TravelManagementSystemContext _db;

        public UserRepository(TravelManagementSystemContext db)
        {
            _db = db;
        }


        //get user name and passform as input and check it is exist in user table
        //if it exist return user details else return null
        public Users validateUser(string username, string password)
        {

            if (_db != null)
            {
                Users dbuser = _db.Users.FirstOrDefault(em => em.UserName == username && em.Password == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;

        }

    }
}
