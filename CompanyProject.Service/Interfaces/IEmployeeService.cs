using CompanyProject.Data.Models;

namespace CompanyProject.Service.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllAsync();
        public IQueryable<Employee> GetAllAsQueryable();
        public Task<Employee> GetByIdAsync(int id);
        public Task<Employee> GetByIdIncludeDepartmentAsync(int id);
        public Task<string> AddAsync(Employee employee);
        public Task<string> EditAsync(Employee employee);
        public Task<bool> IsNameExistAsync(string name);
        public Task<bool> IsNameExistAsync(string name, int Id);
        public Task<string> DeleteAsync(int Id);
    }
}
