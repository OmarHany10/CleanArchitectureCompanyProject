using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Data.Models
{
    public class Project
    {
        public Project() 
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
            DepartmentProjects = new HashSet<DepartmentProject>();
        }
        public int Id { get; set; }

        [MaxLength(50)]
        public string ProjectName { get; set; }
        public DateTime Period {  get; set; }
        
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<DepartmentProject> DepartmentProjects { get; set; }
    }
}
