using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TravelManagementSystem.Models;
using TravelManagementSystem.Repositories;

namespace TravelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectTableRepository projectRepository;

        public ProjectController(IProjectTableRepository _pr)
        {
           projectRepository = _pr;
        }

        #region get Project
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("getproject")]
        public async Task<IActionResult> GetProject()
        {
            try
            {

                var projects = await projectRepository.GetProject();
                if (projects == null)
                {
                    return NotFound();
                }
                return Ok(projects);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        #region add project

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("addproject")]

        public async Task<IActionResult> AddProject([FromBody] ProjectTable project)
        {
            // check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var projectId = await projectRepository.AddProject(project);
                    if (projectId > 0)
                    {
                        return Ok(projectId);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        #endregion



        #region update Project


        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("updateproject")]

        public async Task<IActionResult> UpdateProject([FromBody] ProjectTable project)
        {
            // check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var projectId = await projectRepository.UpdateProject(project);
                    if (projectId > 0)
                    {
                        return Ok(projectId);
                    }
                    else
                    {
                        return NotFound();
                    }


                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        #endregion
    }
}
