using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.BaseRepository;
using CompanyProject.Infrustructure.Context;
using CompanyProject.Infrustructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Infrustructure.Repositories
{
    public class EmployeeRepository :BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly DbSet<Employee> employees;

        public EmployeeRepository(ApplicationDbContext context): base(context)
        {
            employees = context.employees;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await employees.Include(e => e.Department).ToListAsync();
        }
    }
}
