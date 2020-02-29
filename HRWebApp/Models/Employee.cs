using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRWebApp.Models
{
    public class Employee
    {
        [Key]
        [JsonProperty(PropertyName = "Id")]
        public int EmployeeId { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string EmployeeName { get; set; }
        public bool IsLeaveApprover { get; set; }
    }
}
