using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Core.Features.Mapping.Employee
{
    public partial class EmployeeProfile: Profile
    {
        public EmployeeProfile() 
        {
            GetEmployeeListMapping();
            GetEmployeeByIdMapping();
            AddEmployeeMapping();
        }
    }
}
