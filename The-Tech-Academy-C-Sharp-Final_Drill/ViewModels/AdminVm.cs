using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_insurance_drill.ViewModels
{
    public class AdminVm
    {
        public int Id { get; set; }
        public int Quote { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}