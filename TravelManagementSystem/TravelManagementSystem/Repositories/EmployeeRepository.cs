using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        TravelManagementSystemContext db;
        //constructor dependency injection
        public EmployeeRepository(TravelManagementSystemContext _db)
        {
            db = _db;
        }
        #region Add employeee
        public async Task<int> AddEmployee(EmployeeRegistration employee)
        {

            if (db != null)
            {
                await db.EmployeeRegistration.AddAsync(employee);
                await db.SaveChangesAsync();
                return (int)employee.EmpId;
            }
            return 0;
        }
        #endregion
        #region Get Employee
        public async Task<List<EmployeeRegistration>> GetEmployee()
        {
            if (db != null)
            {
                return await db.EmployeeRegistration.ToListAsync();
            }

            return null;
        }
        #endregion

        #region Update Employee
        public async Task<int> UpdateEmployee(EmployeeRegistration employee)
        {
            if (db != null)
            {
                db.EmployeeRegistration.Update(employee);
                await db.SaveChangesAsync();
                return (int)employee.EmpId;
            }
            return 0;
        }
        #endregion
    }
}
