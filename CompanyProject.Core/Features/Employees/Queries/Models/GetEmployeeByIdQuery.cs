using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Core.Features.Employees.Queries.Models
{
    public class GetEmployeeByIdQuery: IRequest<Response<GetEmployeeByIdDTO>>
    {
        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
