using DbHelper.BL.ProjectBL;
using DbHelper.DAL.Common;
using DbHelper.DAL.Common.ProjectResponses;
using DbHelper.DAL.Entities.Requests.ProjectRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbHelper.WebApi.Controllers
{

    [ApiController]
    [Route("api/project")]
    public class ProjectController
    {
        private readonly ProjectManager _projectManager;
        public ProjectController(ProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        public async Task<ProjectResponse> Create(CreateProjectRequest request)
        {
            return await _projectManager.Create(request);
        }
        [HttpGet("info/{projectId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        public async Task<ProjectDTOResponse> GetById(int projectId)
        {
            return await _projectManager.GetById(projectId);
        }
        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ProjectDTOsResponse> GetAll(DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            return await _projectManager.GetAllProjects(startDate, endDate, priority, sortBy);
        }
        [HttpGet("all/my")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager, Employee")]
        public async Task<ProjectDTOsResponse> GetEmployeeProjects(DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            return await _projectManager.GetEmployeeProjects(startDate, endDate, priority, sortBy);
        }
        [HttpGet("all/own")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        public async Task<ProjectDTOsResponse> GetOwnProjects(DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            return await _projectManager.GetOwnProjects(startDate, endDate, priority, sortBy);
        }
        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        public async Task<Response> Update(UpdateProjectRequest request)
        {
            return await _projectManager.Update(request);
        }
        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        public async Task<Response> Delete(int projectId)
        {
            return await _projectManager.Delete(projectId);
        }
    }
}
