using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Data.Models
{
    public class EmployeeProject
    {

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
