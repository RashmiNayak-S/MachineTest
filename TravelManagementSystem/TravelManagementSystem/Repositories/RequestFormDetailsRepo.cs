using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.ViewModel
{
    public class RequestFormDetailsRepo : IRequestFormDetailsRepo
    {

        TravelManagementSystemContext db;
        //constructor dependency injection
        public RequestFormDetailsRepo(TravelManagementSystemContext _db)
        {
            db = _db;
        }
        public async Task<List<RequestFormDetails>> GetRequestFormDetails()
        {
            if (db != null)
            {
                //LINQ
                //joining request table ,employee,project table
                return await (
                              from r in db.RequestTable
                              from e in db.EmployeeRegistration
                              from p in db.ProjectTable
               
                              where r.ProjectId==p.ProjectId
                              where r.EmpId==e.EmpId
                              
                              select new RequestFormDetails
                              {
                                  request_id=r.RequestId,
                                  cause_travel=r.CauseTravel,
                                  source=r.Source,
                                  destination=r.Destination,
                                  mode=r.Mode,
                                  //from_date= r.FromDate,
                                  // to_date=r.ToDate,
                                  no_days=r.NoDays,
                                  priority=r.Priority,
                                  project_Id=p.ProjectId,
                                  EmpId=e.EmpId
                              }
                              ).ToListAsync();

            }
            return null;

        }

        Task<List<RequestFormDetailsRepo>> IRequestFormDetailsRepo.GetRequestFormDetails()
        {
            throw new NotImplementedException();
        }
    }
}
