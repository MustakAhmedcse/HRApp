using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRWebApp.Models
{
    public class LeaveSeting
    {
        [Key]
        public int LeaveSetingId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Approver")]
        public int ApproverId { get; set; }
        public string Leavel { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Approver { get; set; }
    }
}