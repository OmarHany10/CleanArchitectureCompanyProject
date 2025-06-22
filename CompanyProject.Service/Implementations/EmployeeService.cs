using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.Interfaces;
using CompanyProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
        }

        public async Task<string> AddAsync(Employee employee)
        {
            var department = await departmentRepository.GetByIdAsync(employee.DepartmentId);
            if (department == null)
                return $"There are no department has this Id {employee.DepartmentId}";

            await employeeRepository.AddAsync(employee);
            return null;
        }

        public async Task<string> DeleteAsync(int Id)
        {
            var employee = await GetByIdAsync(Id);
            if (employee == null)
                return "Not Found";

            var transiction = employeeRepository.BeginTransaction();
            try
            {
                await employeeRepository.DeleteAsync(employee);
                await transiction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transiction.RollbackAsync();
                return ex.Message;
            }
            return null;
        }

        public async Task<string> EditAsync(Employee employee)
        {
            if (await GetByIdAsync(employee.Id) == null) return "Not Found";
            await employeeRepository.UpdateAsync(employee);
            return null;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await employeeRepository.GetTableNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task<Employee> GetByIdIncludeDepartmentAsync(int id)
        {
            var employee = await employeeRepository.GetTableNoTracking().Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task<bool> IsNameExistAsync(string name)
        {
            var employee = await employeeRepository.GetTableNoTracking().FirstOrDefaultAsync(e => e.Name == name);
            if (employee == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistAsync(string name, int Id)
        {
            var employee = await employeeRepository.GetTableNoTracking().FirstOrDefaultAsync(e => e.Name == name && e.Id != Id);
            if (employee == null) return false;
            return true;
        }
    }
}
