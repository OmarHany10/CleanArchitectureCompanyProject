using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime Period { get; set; }

        [ForeignKey("ProjectLeader")]
        public int ProjectLeaderId { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<DepartmentProject> DepartmentProjects { get; set; }

        public virtual ProjectLeader ProjectLeader { get; set; }
    }
}
