using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.BaseRepository;

namespace CompanyProject.Infrustructure.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<bool> IsExist(int id);
    }
}
