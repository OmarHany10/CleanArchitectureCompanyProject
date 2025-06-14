using CompanyProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Service.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(int id);
        public Task<string> AddAsync(Employee employee);
    }
}
