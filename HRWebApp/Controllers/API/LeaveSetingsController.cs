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
using HRWebApp.Helpers;
using HRWebApp.Models;

namespace HRWebApp.Controllers.API
{
    public class LeaveSetingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/LeaveSetings
        public IHttpActionResult GetLeaveSetings()
        {
            var result = SqlHelper.ExecuteDataTable("", "GetAllLeaveSetings", new object[] { });
            return Json(result);
        }
        
        // POST: api/LeaveSetings
        [ResponseType(typeof(LeaveSeting))]
        public IHttpActionResult PostLeaveSeting(LeaveApprovalRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Employee> employees = new List<Employee>();
            if (req.level == "Employeee")
            {
                employees = db.Employees.Where(e => e.EmployeeId == req.deporemp).ToList();
            }
            else if (req.level == "Department")
            {
                var query =    from post in db.DepartmetnEmployees
                               join meta in db.Employees on post.EmployeeId equals meta.EmployeeId
                               where post.DepartmentId == req.deporemp && post.IsPrimaryDepartment==true
                               select meta;
                employees = query.ToList();
            }
            else if (req.level == "Company")
            {
                employees = db.Employees.ToList();
            }

            string[] approvrsId =req.approvers.Split(',');
            List<Employee> approverlist = new List<Employee>();
            foreach (var item in approvrsId)
            {
                int id = Convert.ToInt32(item);
                Employee emp = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
                approverlist.Add(emp);
            }
           
            var setinglist= from e in employees
                        from ap in approverlist
                        select new LeaveSeting { EmployeeId=e.EmployeeId,ApproverId= ap.EmployeeId,Leavel=req.level };

            foreach (LeaveSeting seting in setinglist)
            {
                bool isNew = !db.LeaveSetings.Where(e => e.EmployeeId == seting.EmployeeId).Any();
                bool IspproverDiff = db.LeaveSetings.Where(e => e.EmployeeId == seting.EmployeeId && e.Leavel == seting.Leavel && e.ApproverId != seting.ApproverId).Any();
               if (isNew || IspproverDiff)
                {
                db.LeaveSetings.Add(seting);
                }
                else if (db.LeaveSetings.Where(e => e.EmployeeId == seting.EmployeeId && e.Leavel != seting.Leavel).Any())
                {
                    List<LeaveSeting> oldSetings = db.LeaveSetings.Where(e => e.EmployeeId == seting.EmployeeId && e.Leavel != seting.Leavel).ToList();
                    if (seting.Leavel == "Employeee" && (oldSetings.FirstOrDefault().Leavel == "Department" || oldSetings.FirstOrDefault().Leavel == "Company"))
                    {
                        // Delete All Old Setings
                        foreach (LeaveSeting oldSeting in oldSetings)
                        {
                            db.LeaveSetings.Remove(oldSeting);
                        }
                        // Add new Seting
                        db.LeaveSetings.Add(seting);
                    }
                    else if (seting.Leavel == "Department" &&  oldSetings.FirstOrDefault().Leavel == "Company")
                    {
                        // Delete All Old Setings
                        foreach (LeaveSeting oldSeting in oldSetings)
                        {
                            db.LeaveSetings.Remove(oldSeting);
                        }
                        // Add new Seting
                        db.LeaveSetings.Add(seting);
                    }


                }


                db.SaveChanges();
            }
            return Ok(0);
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