using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Data.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            DepartmentProjects = new HashSet<DepartmentProject>();
        }
        public int Id { get; set; }

        [MaxLength(50)]
        public string NameEn { get; set; }

        [MaxLength(50)]
        public string NameAr { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<DepartmentProject> DepartmentProjects { get; set; }
    }
}
