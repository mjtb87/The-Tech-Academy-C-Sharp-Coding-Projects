using car_insurance_drill.Models;
using car_insurance_drill.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace car_insurance_drill.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (QuoteDbEntities db = new QuoteDbEntities())
            {
                //var signups = db.SignUps.Where(x => x.Removed == null).ToList();
                var customers = (from c in db.CustomerInfoes
                                 where c.Quote != null
                                 select c).ToList();
                var customerVms = new List<AdminVm>();
                foreach (var customer in customers)
                {
                    var customerVm = new AdminVm();
                    customerVm.Quote = Convert.ToInt32(customer.Quote);
                    customerVm.FirstName = customer.FirstName;
                    customerVm.LastName = customer.LastName;
                    customerVm.EmailAddress = customer.EmailAddress;
                    customerVms.Add(customerVm);
                }

                return View(customerVms);
            }
        }
    }
}