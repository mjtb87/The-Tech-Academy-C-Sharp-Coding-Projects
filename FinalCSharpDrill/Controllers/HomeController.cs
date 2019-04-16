using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCSharpDrill.Controllers
{
    public class HomeController : Controller
    {
        public static bool finalResult = false;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Employee (string firstName, string lastName, string emailAddress, 
                            DateTime dateOfBirth, string title, double salary, string worksRemotely)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress)
                                                || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(worksRemotely))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (var db = new EmployeeDB())
                {
                    var employee = new MyEntity();
                    employee.FirstName = firstName;
                    employee.LastName = lastName;
                    employee.EmailAddress = emailAddress;
                    employee.DateOfBirth = dateOfBirth;
                    employee.Title = title;
                    employee.Salary = Convert.ToDouble(salary);
                    employee.WorksRemotely = CheckBool(worksRemotely);
                 
                    db.MyEntities.Add(employee);
                    db.SaveChanges();                }
                return View("Success");

            }
        }

        public static bool CheckBool(string worksRemote)
        {
            worksRemote = worksRemote.ToUpper();
            if (worksRemote != "YES" && worksRemote != "NO")
            {
                throw new Exception();
            }
            else if (worksRemote == "YES")
            {
                finalResult = true;
            }
            else if (worksRemote == "NO")
            {
                finalResult = false;
            }
            return finalResult;
        }
    }
}