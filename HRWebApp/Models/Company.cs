using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRWebApp.Models
{
    public class Company

    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}