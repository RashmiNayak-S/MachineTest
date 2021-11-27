using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;

namespace TravelManagementSystem.Repositories
{
    public class ProjectTableRepository : IProjectTableRepository
    {
        TravelManagementSystemContext db;
        //constructor dependency injection
        public ProjectTableRepository(TravelManagementSystemContext _db)
        {
            db = _db;
        }
        #region Add project
        public async Task<int> AddProject(ProjectTable project)
        {

            if (db != null)
            {
                await db.ProjectTable.AddAsync(project);
                await db.SaveChangesAsync();
                return (int)project.ProjectId;
            }
            return 0;
        }
        #endregion
        #region Get Project
        public async Task<List<ProjectTable>> GetProject()
        {
            if (db != null)
            {
                return await db.ProjectTable.ToListAsync();
            }

            return null;
        }
        #endregion

        #region Update Project
        public async Task<int> UpdateProject(ProjectTable project)
        {
            if (db != null)
            {
                db.ProjectTable.Update(project);
                await db.SaveChangesAsync();
                return (int)project.ProjectId;
            }
            return 0;
        }
        #endregion
    }
}
