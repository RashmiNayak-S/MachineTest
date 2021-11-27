using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
   public  interface IEmployeeRepository
    {
        //Asyncronous operation

        #region Employee

        //get employee
        Task<List<EmployeeRegistration>> GetEmployee();

        //add new employee
        public Task<int> AddEmployee(EmployeeRegistration employee);

        //update employee

        public Task<int> UpdateEmployee(EmployeeRegistration employee);

        #endregion
    }
}
