using ESAD_CS_R72_M_06_MVC_D010.Models;
using ESAD_CS_R72_M_06_MVC_D010.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace ESAD_CS_R72_M_06_MVC_D010.Controllers
{
   
    public class EmployeesController : Controller
    {
        EmployeeDbContext db = new EmployeeDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            //var employeeInfo = db.Employees.Join(
            //                        db.EmployeeQualifications,
            //                        (e => e.EmployeeId),
            //                        (eq => eq.EmployeeId),
            //                        ((e, eq) => new
            //                        {
            //                            e,
            //                            eq.Qualification
            //                        })
            //                    ).OrderByDescending(e => e.e.EmployeeId)
            //                    .ToList();
            //return View(employeeInfo);

            var employeeInfo = db.Employees
                                 .Include(e => e.EmployeeQualifications.Select(eq => eq.Qualification))
                                 .OrderByDescending(e => e.EmployeeId)
                                 .ToList();
            return View(employeeInfo);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddNewQualification(int? id)
        {

            ViewBag.qualifications = new SelectList(db.Qualifications.ToList(), "QualificationId", "QualificationName", (id != null) ? id.ToString() : "");
            return PartialView("_AddNewQualification");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM evm, int[] qualificationId)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    EmployeeName = evm.EmployeeName,
                    JoinDate = evm.JoinDate,
                    Salary = evm.Salary,
                    IsActive = evm.IsActive
                };

                //For Image

                HttpPostedFileBase file = evm.PicturePath;
                string filePath = "/Images/"+ DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath(filePath));
                employee.Picture = filePath;

                //Qualifications
                foreach (var item in qualificationId)
                {
                    EmployeeQualification eq = new EmployeeQualification()
                    {
                        Employee = employee,
                        EmployeeId = employee.EmployeeId,
                        QualificationId = item
                    };
                    db.EmployeeQualifications.Add(eq);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}