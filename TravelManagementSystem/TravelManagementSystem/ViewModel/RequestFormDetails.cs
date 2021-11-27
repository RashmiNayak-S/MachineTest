using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagementSystem.ViewModel
{
    public class RequestFormDetails
    {
        public long request_id { get; set; }

        public string cause_travel { get; set; }

        public string source { get; set; }

        public string destination { get; set; }

        public string mode { get; set; }

        public DateTime from_date { get; set; }

        public DateTime to_date { get; set; }

        public decimal no_days { get; set; }

        public string priority { get; set; }

        public long project_Id { get; set; }

        public long EmpId { get; set; }

        public string status { get; set; }
    }
}

