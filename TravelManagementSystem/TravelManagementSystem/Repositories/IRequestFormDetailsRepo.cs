using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagementSystem.ViewModel
{
    public interface IRequestFormDetailsRepo
    {
        Task<List<RequestFormDetailsRepo>> GetRequestFormDetails();
    }
}
