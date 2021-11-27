using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
   public interface IProjectTableRepository
    {
        //Asyncronous operation

        #region Project Table

        //get project
        Task<List<ProjectTable>> GetProject();

        //add new project
        public Task<int> AddProject(ProjectTable project);

        //update project

        public Task<int> UpdateProject(ProjectTable project);

        #endregion
    }
}
