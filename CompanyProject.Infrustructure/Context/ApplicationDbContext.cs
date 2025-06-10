using CompanyProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Infrustructure.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() { }
        
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<EmployeeProject> employeeProjects { get; set; }
        public DbSet<DepartmentProject> departmentProjects { get; set; }
    }
}
