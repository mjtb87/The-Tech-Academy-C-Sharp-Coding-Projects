namespace FinalCSharpDrill
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeDB : DbContext
    {
        // Your context has been configured to use a 'EmployeeDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FinalCSharpDrill.EmployeeDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EmployeeDB' 
        // connection string in the application configuration file.
        public EmployeeDB()
            : base("name=EmployeeDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class MyEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public bool WorksRemotely { get; set; }

    }
}