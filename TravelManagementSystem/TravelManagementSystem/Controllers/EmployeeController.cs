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
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository empRepository;

        public EmployeeController(IEmployeeRepository _er)
        {
            empRepository = _er;
        }

        #region get Employee
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("getemployee")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {

                var employee = await empRepository.GetEmployee();
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        #region add Employee

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("addemployee")]

        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRegistration employee)
        {
            // check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await empRepository.AddEmployee(employee);
                    if (empId > 0)
                    {
                        return Ok(empId);
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



        #region update Employee


        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("updateemployee")]

        public async Task<IActionResult> UpdateBook([FromBody] EmployeeRegistration employee)
        {
            // check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await empRepository.UpdateEmployee(employee);
                    if (empId > 0)
                    {
                        return Ok(empId);
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
