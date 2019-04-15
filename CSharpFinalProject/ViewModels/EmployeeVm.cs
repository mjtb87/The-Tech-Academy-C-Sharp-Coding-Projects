using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCSharpDrill.ViewModels
{
    public class EmployeeVm
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int EmailAddress { get; set; }
        public int DateOfBirth { get; set; }
        public int Title { get; set; }
        public int Salary { get; set; }
        public int WorksRemotely { get; set; }
    }
}