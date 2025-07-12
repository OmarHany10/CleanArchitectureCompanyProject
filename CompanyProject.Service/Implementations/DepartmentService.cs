using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.Interfaces;
using CompanyProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public async Task<Department> GetByIDAsync(int id)
        {
            return await departmentRepository.GetTableNoTracking().
                Include(d => d.LeaderManger).Include(d => d.ProjectLeaders).Include(d => d.Employees).Include(d => d.DepartmentProjects).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await departmentRepository.IsExist(id);
        }
    }
}
