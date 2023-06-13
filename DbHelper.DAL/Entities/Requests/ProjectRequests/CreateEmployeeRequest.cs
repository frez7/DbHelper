namespace DbHelper.DAL.Entities.Requests.ProjectRequests
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FatherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
