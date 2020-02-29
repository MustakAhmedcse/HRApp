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
    public class CompaniesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Companies
        public IQueryable<Company> GetCompanies()
        {
            return db.Companies;
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