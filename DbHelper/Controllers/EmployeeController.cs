using DbHelper.BL.ProjectBL;
using DbHelper.DAL.Common;
using DbHelper.DAL.Common.ProjectResponses;
using DbHelper.DAL.Entities.Identity;
using DbHelper.DAL.Entities.Requests.ProjectRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbHelper.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeManager _employeeManager;
        public EmployeeController(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<EmployeeResponse> Create(CreateEmployeeRequest request)
        {
            return await _employeeManager.Create(request);
        }
        [HttpGet("info/{employeeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<EmployeeDTOResponse> GetById(int employeeId)
        {
            return await _employeeManager.GetById(employeeId);
        }
        [HttpGet("all/employees")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        public async Task<EmployeeDTOsResponse> GetAll()
        {
            return await _employeeManager.GetAllEmployees();
        }
        [HttpGet("all/managers")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Manager")]
        public async Task<EmployeeDTOsResponse> GetAllManagers()
        {
            return await _employeeManager.GetAllManagers();
        }
        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<Response> Update(UpdateEmployeeRequest request)
        {
            return await _employeeManager.Update(request);
        }
        [HttpPut("update/role/employee/{employeeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<Response> UpdateToEmployeeRole(int employeeId)
        {
            return await _employeeManager.UpdateToEmployeeRole(employeeId);
        }
        [HttpPut("update/role/manager/{employeeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<Response> UpdateToManagerRole(int employeeId)
        {
            return await _employeeManager.UpdateToManagerRole(employeeId);
        }
        [HttpPut("update/role/admin/{employeeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<Response> UpdateToAdminRole(int employeeId)
        {
            return await _employeeManager.UpdateToAdminRole(employeeId);
        }
        [HttpDelete("delete/{employeeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<Response> Delete(int employeeId)
        {
            return await _employeeManager.Delete(employeeId);
        }
    }
}
