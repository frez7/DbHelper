namespace DbHelper.DAL.Common.ProjectResponses
{
    public class EmployeeResponse : Response
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EmployeeResponse(int statusCode, bool success, string message, int employeeId, string email, string password) : base(statusCode, success, message)
        {
            EmployeeId = employeeId;
            Email = email;
            Password = password;
        }
    }
}
