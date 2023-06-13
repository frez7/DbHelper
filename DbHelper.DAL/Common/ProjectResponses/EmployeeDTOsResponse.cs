using DbHelper.DAL.Entities.DTOs;

namespace DbHelper.DAL.Common.ProjectResponses
{
    public class EmployeeDTOsResponse : Response
    {
        public List<EmployeeDTO> EmployeeDTOs { get; set; }
        public EmployeeDTOsResponse(int statusCode, bool success, string message, List<EmployeeDTO> employeeDTOs) : base(statusCode, success, message)
        {
            EmployeeDTOs = employeeDTOs;
        }
    }
}
