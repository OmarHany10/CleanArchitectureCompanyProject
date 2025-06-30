using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Data.Models
{
    public class DepartmentProject
    {

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }


        public virtual Department Department { get; set; }
        public virtual Project Project { get; set; }
    }
}
