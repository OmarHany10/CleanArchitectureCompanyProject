using CompanyProject.Data.Models;

namespace CompanyProject.Service.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(int id);
        public Task<string> AddAsync(Employee employee);
        public Task<bool> IsNameExistAsync(string name);
    }
}
