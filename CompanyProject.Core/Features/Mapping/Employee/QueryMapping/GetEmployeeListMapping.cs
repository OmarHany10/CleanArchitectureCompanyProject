using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Core.Features.Mapping.Employee
{
    public partial class EmployeeProfile
    {
        public void GetEmployeeListMapping()
        {
            CreateMap<Data.Models.Employee, GitEmployeeListDTO>().
                ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));

        }
    }
}
