using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Data.Models
{
    public class ProjectLeader
    {
        public ProjectLeader()
        {
            Subordinates = new HashSet<ProjectLeader>();
            Projects = new HashSet<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public Decimal Salary { get; set; }

        public int? SupervisorId { get; set; }
        public int DepartmentId { get; set; }


        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty(nameof(Subordinates))]
        public virtual ProjectLeader Supervisor { get; set; }

        [InverseProperty(nameof(Supervisor))]
        public virtual ICollection<ProjectLeader> Subordinates { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Department.ProjectLeaders))]
        public virtual Department Department { get; set; }

        [InverseProperty("LeaderManger")]
        public virtual Department DepartmentManger { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

    }
}
