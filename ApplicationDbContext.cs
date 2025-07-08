using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeAdminPortal.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStaff> EmployeeStaffs { get; set; }
        public DbSet<EmployeeSubStaff> EmployeeSubStaffs { get; set; }

    }

}