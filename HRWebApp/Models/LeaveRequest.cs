using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRWebApp.Models
{
    public class LeaveRequest
    {
        public string level { get; set; }
        public string approvers { get; set; }
        public int deporemp { get; set; }

    }
}