using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementSystem.ViewModel;

namespace TravelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewModelController : ControllerBase
    {
        IRequestFormDetailsRepo viewModelRepository;

        public ViewModelController(IRequestFormDetailsRepo _vr)
        {
            viewModelRepository = _vr;
        }
        #region Get Book and Authors
        [HttpGet]
        [Route("GetRequestFormDetails")]
        public async Task<IActionResult> GetRequestFormDetails()
        {
            try
            {
                var details = await viewModelRepository.GetRequestFormDetails();
                if (details == null)
                {
                    return NotFound();
                }
                return Ok(details);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
