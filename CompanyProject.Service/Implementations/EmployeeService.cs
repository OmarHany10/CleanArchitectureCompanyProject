using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.Interfaces;
using CompanyProject.Service.Interfaces;
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

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await employeeRepository.GetAllAsync();
        }
    }
}
