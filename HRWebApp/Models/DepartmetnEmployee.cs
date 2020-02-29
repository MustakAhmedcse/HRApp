using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRWebApp.Models
{
    public class DepartmetnEmployee
    {
        [Key]
        public int DepartmentEmployeeId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public bool IsPrimaryDepartment { get; set; }
        public Department Department { get; set; }
        public Employee Employee { get; set; }
    }
}
