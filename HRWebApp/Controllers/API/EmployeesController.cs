using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HRWebApp.Models;

namespace HRWebApp.Controllers.API
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }
        // GET: api/EmployeesApprovers
        [HttpGet]
        [Route("api/EmployeesApprovers")]
        public IQueryable<Employee> EmployeesApprovers()
        {
            return db.Employees.Where(e=>e.IsLeaveApprover==true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}