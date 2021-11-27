using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
    public class RequestTableRepository :IRequestTableRepository
    {
        TravelManagementSystemContext db;
        //constructor dependency injection
        public RequestTableRepository(TravelManagementSystemContext _db)
        {
            db = _db;
        }
        #region Add request
        public async Task<int> AddRequest(RequestTable request)
        {

            if (db != null)
            {
                await db.RequestTable.AddAsync(request);
                await db.SaveChangesAsync();
                return (int)request.RequestId;
            }
            return 0;
        }
        #endregion
        #region Get Request
        public async Task<List<RequestTable>> GetRequest()
        {
            if (db != null)
            {
                return await db.RequestTable.ToListAsync();
            }

            return null;
        }
        #endregion

        #region Update Request
        public async Task<int> UpdateRequest(RequestTable request)
        {
            if (db != null)
            {
                db.RequestTable.Update(request);
                await db.SaveChangesAsync();
                return (int)request.RequestId;
            }
            return 0;
        }
        #endregion
    }
}
