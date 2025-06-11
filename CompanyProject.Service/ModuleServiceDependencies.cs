using CompanyProject.Service.Implementations;
using CompanyProject.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
