using CompanyProject.Data.Models;
using CompanyProject.Infrustructure.BaseRepository;
using CompanyProject.Infrustructure.Context;
using CompanyProject.Infrustructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Infrustructure.Repositories
{
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
