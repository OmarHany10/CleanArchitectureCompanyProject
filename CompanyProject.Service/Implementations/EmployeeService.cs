using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.Interfaces;
using CompanyProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return $"There is no department has this Id {employee.DepartmentId}";

            await employeeRepository.AddAsync(employee);
            return null;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await employeeRepository.GetTableNoTracking().Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }
    }
}
