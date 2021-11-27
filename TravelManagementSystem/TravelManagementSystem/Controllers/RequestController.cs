using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.Models;
using TravelManagementSystem.Repositories;

namespace TravelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        IRequestTableRepository requestRepository;

        public RequestController(IRequestTableRepository _pr)
        {
            requestRepository = _pr;
        }

        #region get Request
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("getrequest")]
        public async Task<IActionResult> GetRequest()
        {
            try
            {

                var requests = await requestRepository.GetRequest();
                if (requests == null)
                {
                    return NotFound();
                }
                return Ok(requests);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        #region add request

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("addrequest")]

        public async Task<IActionResult> AddRequest([FromBody] RequestTable request)
        {
            // check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var requestId = await requestRepository.AddRequest(request);
                    if (requestId > 0)
                    {
                        return Ok(requestId);
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



        #region update Request


        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("updaterequest")]

        public async Task<IActionResult> UpdateRequest([FromBody] RequestTable request)
        {
            // check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var requestId = await requestRepository.UpdateRequest(request);
                    if (requestId > 0)
                    {
                        return Ok(requestId);
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
