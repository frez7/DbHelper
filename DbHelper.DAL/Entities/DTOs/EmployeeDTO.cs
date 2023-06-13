using DbHelper.DAL.Entities.DbHelper;

namespace DbHelper.DAL.Entities.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FatherName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
