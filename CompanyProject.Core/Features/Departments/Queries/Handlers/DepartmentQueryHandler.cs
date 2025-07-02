using AutoMapper;
using CompanyProject.Core.Features.Departments.Queries.DTOs;
using CompanyProject.Core.Features.Departments.Queries.Models;
using CompanyProject.Core.Resources;
using CompanyProject.Core.Responses;
using CompanyProject.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CompanyProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdDTO>>
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentHandler(IStringLocalizer<SharedResource> stringLocalizer, IDepartmentService departmentService, IMapper mapper) : base(stringLocalizer)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        public async Task<Response<GetDepartmentByIdDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await departmentService.GetByIDAsync(request.Id);

            if (department == null)
                return NotFound<GetDepartmentByIdDTO>();

            var respone = mapper.Map<GetDepartmentByIdDTO>(department);
            return Success(respone);
        }
    }

}
