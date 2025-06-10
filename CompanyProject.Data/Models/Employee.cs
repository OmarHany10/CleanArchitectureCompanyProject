using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Data.Models
{
    public class Employee
    {
        public Employee() 
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
        }
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength (100)]
        public string Phone { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
