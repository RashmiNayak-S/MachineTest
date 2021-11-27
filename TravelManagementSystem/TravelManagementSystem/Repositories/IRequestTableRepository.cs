using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
   public interface IRequestTableRepository
    {
        //Asyncronous operation

        #region Request Table

        //get request
        Task<List<RequestTable>> GetRequest();

        //add new request
        public Task<int> AddRequest(RequestTable request);

        //update request

        public Task<int> UpdateRequest(RequestTable request);

        #endregion
    }
}
