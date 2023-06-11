using DbHelper.DAL.Entities.DbHelper;
using Microsoft.AspNetCore.Identity;

namespace DbHelper.DAL.Entities.Identity
{
    public class Employee : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FatherName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public List<ProjectEmployee>? ProjectEmployees { get; set; }

    }
}
