namespace CompanyProject.Core.Features.Departments.Queries.DTOs
{
    public class GetDepartmentByIdDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MangerName { get; set; }

        public List<ItemDTO> Employees { get; set; }
        public List<ItemDTO> Projects { get; set; }
        public List<ItemDTO> ProjectLeaders { get; set; }

    }

    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
