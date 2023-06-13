using DbHelper.BL.ProjectBL;
using DbHelper.DAL.Common;
using DbHelper.DAL.Common.ProjectResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbHelper.WebApi.Controllers
{
    [ApiController]
    [Route("api/project/employee")]
    public class ProjectEmployeeController
    {
        private readonly ProjectEmployeeManager _manager;
        public ProjectEmployeeController(ProjectEmployeeManager manager)
        {
            _manager = manager;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        [HttpPost("add")]
        public async Task<Response> AddEmployeeToProject(int employeeId, int projectId)
        {
            return await _manager.AddEmployeeToProject(employeeId, projectId);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet("{employeeId}/projects")]
        public async Task<ProjectDTOsResponse> GetAllEmployeeProjects(int employeeId, DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            return await _manager.GetAllEmployeeProjects(employeeId, startDate, endDate, priority, sortBy);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        [HttpGet("{projectId}/all")]
        public async Task<EmployeeDTOsResponse> GetAllProjectEmployees(int projectId)
        {
            return await _manager.GetAllProjectEmployees(projectId);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        [HttpDelete("remove")]
        public async Task<Response> RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            return await _manager.RemoveEmployeeFromProject(employeeId, projectId);
        }
    }
}
