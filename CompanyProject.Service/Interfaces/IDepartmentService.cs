using CompanyProject.Data.Models;

namespace CompanyProject.Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> GetByIDAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}
