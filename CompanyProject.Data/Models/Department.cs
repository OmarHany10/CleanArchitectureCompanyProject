using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Data.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            DepartmentProjects = new HashSet<DepartmentProject>();
            ProjectLeaders = new HashSet<ProjectLeader>();
        }
        public int Id { get; set; }

        [MaxLength(50)]
        public string NameEn { get; set; }

        [MaxLength(50)]
        public string NameAr { get; set; }

        public int? LeaderMangerId { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<DepartmentProject> DepartmentProjects { get; set; }

        [InverseProperty(nameof(ProjectLeader.Department))]
        public virtual ICollection<ProjectLeader> ProjectLeaders { get; set; }

        [ForeignKey(nameof(LeaderMangerId))]
        [InverseProperty(nameof(ProjectLeader.DepartmentManger))]
        public virtual ProjectLeader LeaderManger { get; set; }
    }
}
