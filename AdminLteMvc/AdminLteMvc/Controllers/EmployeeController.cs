using AdminLteMvc.Models;
using AdminLteMvc.Models.WEBSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private ContextModel db = new ContextModel();
        protected void loadable() 
        {
            var jobTitle = db.JobTitle.Where(a => a.Active == true).ToList();
            List<SelectListItem> jobTitleList = new List<SelectListItem>();
            foreach (JobTitle item in jobTitle)
            {
                jobTitleList.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.jobtitleID.ToString()
                });
            }
            ViewBag.jobTitleList = jobTitleList;
            var Department = db.Department.Where(a => a.Active == true).ToList();
            List<SelectListItem> DepartmentList = new List<SelectListItem>();
            foreach (Department item in Department)
            {
                DepartmentList.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.DeptID.ToString()
                });
            }
            ViewBag.DepartmentList = DepartmentList;

            var Branch = db.Branch.Where(a => a.Active == true).ToList();
            List<SelectListItem> BranchList = new List<SelectListItem>();
            foreach (Branch item in Branch)
            {
                BranchList.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.BranchID.ToString()
                });
            }
            ViewBag.BranchList = BranchList;

        }
        public ActionResult EmployeeList()
        {
            loadable();
            var Employee = db.EmployeeMasters.ToList();
            ViewBag.Employee = Employee;
            return View();
        }
        public ActionResult save(List<EmployeeMaster> emp)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            bool status = true;
            try {
                foreach (EmployeeMaster em in emp)
                {
                    var chk = db.EmployeeMasters.Where(a=>a.IDNO==em.IDNO).ToList();
                    if (chk.Count == 0)
                    {
                        EmployeeMaster rr = db.EmployeeMasters.Add(em);
                        rr.Status = "Active";
                        rr.dateCreated = DateTime.Now;
                        var ret = db.EmployeeMasters.Add(rr);
                        db.SaveChanges();
                    }
                }
                transaction.Commit();
                TempData["message"] = "saved";
            }
            catch (Exception ex)
            { 
                transaction.Rollback();
                status = false;
                TempData["message"] = "failed";
            }
            
            return new JsonResult { Data = new { status = status } };
        }
        public ActionResult cancelEmployee(int Id)
        {
            bool status = true;
            var emp= db.EmployeeMasters.Find(Id);
            emp.Status = "InActive";
            db.SaveChanges();
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult setUser(int Id,string usrType)
        {
            bool status = true;
            DbContextTransaction transaction = db.Database.BeginTransaction();
            try {
                var emp = db.EmployeeMasters.Where(a=>a.ID==Id).SingleOrDefault();
                emp.isUser = true;
                db.SaveChanges();

                Users usr = new Users();
                usr.UserName = Functions.Hash.Encrypt(emp.IDNO, true);
                usr.Password = Functions.Hash.Encrypt(emp.IDNO, true);
                usr.userType = usrType;
                usr.EmpID = emp.ID.ToString();
                usr.dateCreated = DateTime.Now;
                usr.active = true;
                db.Users.Add(usr);
                db.SaveChanges();
                transaction.Commit();
            } 
            catch (Exception ex)
            {
                transaction.Rollback();
                status = false;
            }
           
            return new JsonResult { Data = new { status = status } };
        }

    }
}