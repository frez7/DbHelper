using DbHelper.BL.OtherServices;
using DbHelper.DAL.Common;
using DbHelper.DAL.Common.ProjectResponses;
using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.DTOs;
using DbHelper.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace DbHelper.BL.ProjectBL
{
    public class ProjectEmployeeManager
    {
        private readonly ProjectEmployeeRepository _projectEmployeeRepository;
        private readonly ProjectRepository _projectRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly GetUserService _getUserService;
        private readonly FilterService _filterService;
        private readonly UserManager<Employee> _userManager;

        public ProjectEmployeeManager(ProjectEmployeeRepository projectEmployeeRepository,
            ProjectRepository projectRepository, IRepository<Employee> employeeRepository,
            GetUserService getUserService, FilterService filterService, UserManager<Employee> userManager)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
            _getUserService = getUserService;
            _filterService = filterService;
            _userManager = userManager;
        }
        public async Task<Response> AddEmployeeToProject(int employeeId, int projectId)
        {
            var ownerId = await _getUserService.GetCurrentUserId();
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            var project = await _projectRepository.GetByIdAsync(projectId);
            var projectEmployee = new ProjectEmployee
            {
                Employee = employee,
                Project = project,
            };
            var projects = await _projectRepository.GetEmployeeProjects(employeeId);
            if (projects.Contains(project))
            {
                return new Response(400, false, "Данного сотрудник уже есть в данном проекте!");
            } 
            await _projectEmployeeRepository.AddAsync(projectEmployee);
            return new Response(200, true, "Вы успешно добавили сотрудника в данный проект");
        }
        public async Task<ProjectDTOsResponse> GetAllEmployeeProjects(int employeeId, DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                throw new Exception("Такого сотрудника не существует!");
            }
            var projects = await _filterService.GetEmployeeProjects(employeeId, startDate, endDate, priority, sortBy);
            var projectsDTOs = new List<ProjectDTO>();
            foreach (var project in projects)
            {
                var projectDTO = new ProjectDTO
                {
                    Priority = project.Priority,
                    CompletedAt = project.CompletedAt,
                    CustomerName = project.CustomerName,
                    ExecutorName = project.ExecutorName,
                    Id = project.Id,
                    Name = project.Name,
                    OwnerId = project.OwnerId,
                    StartedAt = project.StartedAt,
                };
                projectsDTOs.Add(projectDTO);
            }
            return new ProjectDTOsResponse(200, true, null, projectsDTOs);
        }
        public async Task<EmployeeDTOsResponse> GetAllProjectEmployees(int projectId)
        {
            var owner = await _getUserService.GetCurrentUser();
            var ownerRoles = await _getUserService.GetCurrentUserRoles();
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Такого проекта не существует!");
            }
            var employees = await _projectRepository.GetProjectEmployees(projectId);
            var employeeDTOs = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                var roles = await _userManager.GetRolesAsync(employee);
                var employeeDTO = new EmployeeDTO
                {
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    FatherName = employee.FatherName,
                    Id = employee.Id,
                    Roles = roles.ToList(),
                };
                employeeDTOs.Add(employeeDTO);
            }
            if (project.OwnerId == owner.Id || ownerRoles.Contains("Admin"))
            {
                return new EmployeeDTOsResponse(200, true, null, employeeDTOs);
            }
            throw new Exception("У вас недостаточно прав!");
        }
        public async Task<Response> RemoveEmployeeFromProject(int employeeId, int projectId)
        {
        var owner = await _getUserService.GetCurrentUser();
        var roles = await _getUserService.GetCurrentUserRoles();
        var employee = await _employeeRepository.GetByIdAsync(employeeId);
        if (employee == null)
        {
            throw new Exception("Данного сотрудника не существует!");
        }
        var project = await _projectRepository.GetByIdAsync(projectId);
        if (project == null)
        {
            throw new Exception("Данного проекта не существует!");
        }
        var ownProjects = await _projectRepository.GetOwningProject(owner.Id);
        if (!ownProjects.Contains(project))
        {
            if (roles.Contains("Admin"))
            {
                var projects1 = await _projectRepository.GetEmployeeProjects(employeeId);
                if (!projects1.Contains(project))
                {
                    throw new Exception("Данного сотрудника не существует в данном проекте!");
                }
                await _projectEmployeeRepository.DeleteProjectEmployee(projectId, employeeId);
                return new Response(200, true, "Вы успешно удалили сотрудника из данного проекта");
            }
            throw new Exception("Вы не менеджер данного проекта!");
        }
        var projects = await _projectRepository.GetEmployeeProjects(employeeId);
        if (!projects.Contains(project))
        {
            throw new Exception("Данного сотрудника не существует в данном проекте!");
        }
        await _projectEmployeeRepository.DeleteProjectEmployee(projectId, employeeId);
        return new Response(200, true, "Вы успешно удалили сотрудника из данного проекта");
        }
    }
}
