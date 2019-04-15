using FinalCSharpDrill.ViewModels;
using FinalCSharpDrill.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCSharpDrill.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (var db = new EmployeeDB())
            {
                var employeeVms = new List<MyEntity>();
                foreach (var employee in db.MyEntities)
                {
                    var employeeVm = new MyEntity();
                    employeeVm.FirstName = employee.FirstName;
                    employeeVm.LastName = employee.LastName;
                    employeeVm.EmailAddress = employee.EmailAddress;
                    employeeVm.DateOfBirth = employee.DateOfBirth;
                    employeeVm.Title = employee.Title;
                    employeeVm.Salary = Convert.ToInt32(employee.Salary);
                    employeeVm.WorksRemotely = employee.WorksRemotely;
                    employeeVms.Add(employeeVm);
                }

                return View(employeeVms);
            }
        }
    }
}