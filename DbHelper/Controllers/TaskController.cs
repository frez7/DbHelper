using DbHelper.BL.ProjectBL;
using DbHelper.DAL.Common.ProjectResponses;
using DbHelper.DAL.Entities.Requests.ProjectRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbHelper.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskManager _taskManager;
        public TaskController(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager, Admin")]
        [HttpPost("create")]
        public async Task<TaskResponse> Create(CreateTaskRequest request)
        {
            return await _taskManager.Create(request);
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager, Admin")]
        [HttpPut("update")]
        public async Task<TaskResponse> Update(UpdateTaskRequest request)
        {
            return await _taskManager.Update(request);
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager, Admin, Employee")]
        [HttpPut("update/{taskId}/{status}")]
        public async Task<TaskResponse> UpdateStatus(int taskId, int status)
        {
            return await _taskManager.UpdateStatus(taskId, status);
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet("all")]
        public async Task<TaskDTOsResponse> GetAllTasks()
        {
            return await _taskManager.GetAllTasks();
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager, Employee")]
        [HttpGet("all/task/{taskId}")]
        public async Task<TaskDTOResponse> GetTaskById(int taskId)
        {
            return await _taskManager.GetTaskById(taskId);
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        [HttpGet("all/owning/{managerId}")]
        public async Task<TaskDTOsResponse> GetAllOwningTasks(int managerId)
        {
            return await _taskManager.GetAllOwningTasks(managerId);
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager, Employee")]
        [HttpGet("all/executing/{executorId}")]
        public async Task<TaskDTOsResponse> GetAllExecutingTasks(int executorId)
        {
            return await _taskManager.GetAllExecutingTasks(executorId);
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        [HttpGet("all/project-tasks/{projectId}")]
        public async Task<TaskDTOsResponse> GetAllProjectTasks(int projectId)
        {
            return await _taskManager.GetAllProjectTasks(projectId);
        }
    }
}
