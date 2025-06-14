using CompanyProject.Infrustructure.Interfaces;
using CompanyProject.Infrustructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyProject.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return services;
        }
    }
}
