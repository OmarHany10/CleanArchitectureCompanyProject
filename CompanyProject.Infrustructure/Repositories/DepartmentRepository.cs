using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.BaseRepository;
using CompanyProject.Infrustructure.Context;
using CompanyProject.Infrustructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Infrustructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> departments;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            departments = context.departments;
        }

        public Task<bool> IsExist(int id)
        {
            return departments.AnyAsync(x => x.Id == id);
        }
    }
}
