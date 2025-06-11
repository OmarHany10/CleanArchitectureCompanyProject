using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.Context;
using CompanyProject.Infrustructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Infrustructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await context.employees.ToListAsync();
        }
    }
}
