using DbHelper.DAL.Entities.DTOs;

namespace DbHelper.DAL.Common.ProjectResponses
{
    public class EmployeeDTOResponse : Response
    {
        public EmployeeDTO EmployeeDTO { get; set; }
        public EmployeeDTOResponse(int statusCode, bool success, string message, EmployeeDTO employeeDTO) : base(statusCode, success, message)
        {
            EmployeeDTO = employeeDTO;
        }
    }
}
