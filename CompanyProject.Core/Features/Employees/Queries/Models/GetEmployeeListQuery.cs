using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Core.Responses;
using CompanyProject.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Core.Features.Employees.Queries.Models
{
    public class GetEmployeeListQuery: IRequest<Response<List<GitEmployeeListDTO>>>
    {
        
    }
}
