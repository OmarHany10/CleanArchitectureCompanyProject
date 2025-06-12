using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Infrustructure.Interfaces
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        public Task<List<Employee>> GetAllAsync();
    }
}
