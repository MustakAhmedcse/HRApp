using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRWebApp.Models
{
    public class Department
    {
        [Key]
        [JsonProperty(PropertyName = "Id")]
        public int DepartmentId { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string DepartmentName { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
