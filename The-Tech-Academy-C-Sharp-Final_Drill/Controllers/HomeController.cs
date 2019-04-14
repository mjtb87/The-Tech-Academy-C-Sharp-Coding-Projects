using car_insurance_drill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace car_insurance_drill.Controllers
{
    public class HomeController : Controller
    {
        public static bool finalResult = false;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerInfo(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, DateTime carYear,
                            string carMake, string carModel,  string speedingTickets, string fullCoverage, string dui, double quote = 0)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress)
                                                || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel)
                                                || string.IsNullOrEmpty(speedingTickets))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (QuoteDbEntities db = new QuoteDbEntities())
                {
                    var customer = new CustomerInfo();
                    customer.FirstName = firstName;
                    customer.LastName = lastName;
                    customer.EmailAddress = emailAddress;
                    customer.DateOfBirth = dateOfBirth;
                    customer.CarYear = carYear;
                    customer.CarMake = carMake;
                    customer.CarModel = carModel;
                    customer.Dui = CheckBool(dui);
                    customer.SpeedingTickets = Convert.ToInt32(speedingTickets);
                    customer.FullCoverage = CheckBool(fullCoverage);
                    quote = CalculateQuote(firstName, lastName, emailAddress, dateOfBirth, carYear, carMake, carModel, CheckBool(dui), speedingTickets, CheckBool(fullCoverage), quote);
                    customer.Quote = quote;

                    db.CustomerInfoes.Add(customer);
                    db.SaveChanges();
                    ViewBag.Message = quote;
                }
                return View("QuotePage");
                
            }
        }

        public static double CalculateQuote(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, DateTime carYear,
                            string carMake, string carModel, bool dui, string speedingTickets, bool fullCoverage, double quote)
        {
            double runningQuote = 0;

            using (QuoteDbEntities db = new QuoteDbEntities())
            {
                var customer = new CustomerInfo();
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.EmailAddress = emailAddress;
                customer.DateOfBirth = dateOfBirth;
                customer.CarYear = carYear;
                customer.CarMake = carMake;
                customer.CarModel = carModel;
                customer.Dui = dui;
                customer.SpeedingTickets = Convert.ToInt32(speedingTickets);
                customer.FullCoverage = fullCoverage;
                customer.Quote = quote;

                int tickets = Convert.ToInt32(speedingTickets);
                runningQuote = 50;

                DateTime zeroTime = new DateTime(1, 1, 1);
                DateTime todaysDate = DateTime.Now;
                TimeSpan span = todaysDate - dateOfBirth;
                int age = (zeroTime + span).Year - 1;


                if (age < 25 && age > 17)
                {
                    runningQuote += 25;
                }
                else if (age < 18)
                {
                    runningQuote += 100;
                }
                else if (age > 100)
                {
                    runningQuote += 25;
                }

                int year = carYear.Year;
                if (year < 2000)
                {
                    runningQuote += 25;
                }
                else if (year > 2005) ;
                {
                    runningQuote += 25;
                }

                if (carMake == "Porsche")
                {
                    runningQuote += 25;
                }

                if (carMake == "Porsche" && carModel == "911 Carrera")
                {
                    runningQuote += 25;
                }

                if (tickets > 1)
                {
                    runningQuote += (10 * tickets);
                }

                if (dui)
                {
                    runningQuote += (runningQuote + (runningQuote * .25));
                }

                if (fullCoverage)
                {
                    runningQuote += (runningQuote + (runningQuote * .50));
                }
            }
            return runningQuote;      
        }

        public ActionResult QuotePage()
        {
            using (QuoteDbEntities db = new QuoteDbEntities())
            {
                var customer = new CustomerInfo();
                
                    customer.FirstName = customer.FirstName;
                    customer.LastName = customer.LastName;
                    customer.EmailAddress = customer.EmailAddress;
                    customer.Quote = customer.Quote;

                return View(customer);
            }
        }

        public static bool CheckBool(string currentStatCheck)
        {
            currentStatCheck = currentStatCheck.ToUpper();
            if (currentStatCheck != "YES" && currentStatCheck != "NO")
            {
                throw new Exception();
            }
            else if (currentStatCheck == "YES")
            {
                finalResult = true;
            }
            else if (currentStatCheck == "NO")
            {
                finalResult = false;
            }
            return finalResult;
        }
    }
}
