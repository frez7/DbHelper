using DbHelper.BL.OtherServices;
using DbHelper.DAL.Common;
using DbHelper.DAL.Common.ProjectResponses;
using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.DTOs;
using DbHelper.DAL.Entities.Identity;
using DbHelper.DAL.Entities.Requests.ProjectRequests;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DbHelper.BL.ProjectBL
{
    public class ProjectManager
    {
        private readonly ProjectRepository _projectRepository;
        private readonly IRepository<ProjectEmployee> _projectEmployeeRepository;
        private readonly GetUserService _getUserService;
        private readonly ValidateService _validateService;
        private readonly FilterService _filterService;
        public ProjectManager(ProjectRepository repository, GetUserService getUserService, 
            IRepository<ProjectEmployee> projectEmployeeRepository, ValidateService validateService, FilterService filterService)
        {
            _projectRepository = repository;
            _getUserService = getUserService;
            _projectEmployeeRepository = projectEmployeeRepository;
            _validateService = validateService;
            _filterService = filterService;
        }
        public async Task<ProjectResponse> Create(CreateProjectRequest request)
        {
            var ownerId = await _getUserService.GetCurrentUserId();
            var project = new Project
            {
                Name = request.Name,
                CustomerName = request.CustomerName,
                ExecutorName = request.ExecutorName,
                StartedAt = DateTime.UtcNow,
                OwnerId = ownerId,
                Priority = request.Priority,
            };
            
            await _projectRepository.AddAsync(project);

            return new ProjectResponse(200, true, "Проект успешно создан!", project.Id);

        }
        public async Task<ProjectDTOsResponse> GetOwnProjects(DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            var user = await _getUserService.GetCurrentUser();
            var projects = await _filterService.GetOwnProjects(user.Id, startDate, endDate, priority, sortBy);
            var projectDTOs = new List<ProjectDTO>();
            foreach (var project in projects)
            {
                var projectDTO = new ProjectDTO
                {
                    Name = project.Name,
                    CustomerName = project.CustomerName,
                    ExecutorName = project.ExecutorName,
                    StartedAt = project.StartedAt,
                    OwnerId = user.Id,
                    Priority = project.Priority,
                    CompletedAt = project.CompletedAt,
                    Id = project.Id
                };
                projectDTOs.Add(projectDTO);
            }
            return new ProjectDTOsResponse(200, true, null, projectDTOs);
        }
        public async Task<ProjectDTOResponse> GetById(int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект с таким айди не существует!");
            }
            var validate = await _validateService.GetProjectPerms(projectId);
            if (validate == false)
            {
                throw new Exception("Недостаточно прав!");
            }
            var projectDTO = new ProjectDTO
            {
                Name = project.Name,
                CustomerName = project.CustomerName,
                ExecutorName = project.ExecutorName,
                CompletedAt = project.CompletedAt,
                StartedAt = project.StartedAt,
                Id = projectId,
                OwnerId = project.OwnerId,
                Priority = project.Priority,
            };
            return new ProjectDTOResponse(200, true, null, projectDTO);
        }
        public async Task<Response> Update(UpdateProjectRequest request)
        {
            var project =  await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
            {
                throw new Exception("Проект с таким айди не существует!");
            }
            var validate = await _validateService.GetUpdateProjectPerms(request.Id);
            if (validate == false)
            {
                throw new Exception("Недостаточно прав!");
            }
            project.StartedAt = request.StartedAt;
            project.Priority = request.Priority;
            project.CompletedAt = request.CompletedAt;
            project.CustomerName = request.CustomerName;
            project.ExecutorName = request.ExecutorName;
            project.Name = request.Name;
            await _projectRepository.UpdateAsync(project);
            return new Response(200, true, "Информация о проекте успешно обновлена!");
        }
        public async Task<Response> Delete(int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new Exception("Проект с таким айди не существует!");
            }
            var validate = await _validateService.GetUpdateProjectPerms(projectId);
            if (validate == false)
            {
                throw new Exception("Недостаточно прав!");
            }
            await _projectRepository.DeleteAsync(projectId);
            return new Response(200, true, "Проект был успешно удален!");
        }
        public async Task<ProjectDTOsResponse> GetEmployeeProjects(DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            var user = await _getUserService.GetCurrentUser();
            var projects = await _filterService.GetEmployeeProjects(user.Id, startDate, endDate, priority, sortBy);
            var projectsDTO = new List<ProjectDTO>();
            for (int i = 0; i < projects.Count; i++)
            {
                var projectDTO = new ProjectDTO()
                {
                    CompletedAt = projects[i].CompletedAt,
                    CustomerName = projects[i].CustomerName,
                    ExecutorName = projects[i].ExecutorName,
                    Id = projects[i].Id,
                    Name = projects[i].Name,
                    OwnerId = projects[i].OwnerId,
                    Priority = projects[i].Priority,
                    StartedAt = projects[i].StartedAt,
                };
                projectsDTO.Add(projectDTO);
            }
                return new ProjectDTOsResponse(200, true, null, projectsDTO);
        }
        public async Task<ProjectDTOsResponse> GetAllProjects(DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            List<Project> projects = await _filterService.GetAllProjects(startDate, endDate, priority, sortBy);
            var projectsDTO = new List<ProjectDTO>();
            for (int i = 0; i < projects.Count; i++)
            {
                var projectDTO = new ProjectDTO()
                {
                    CompletedAt = projects[i].CompletedAt,
                    CustomerName = projects[i].CustomerName,
                    ExecutorName = projects[i].ExecutorName,
                    Id = projects[i].Id,
                    Name = projects[i].Name,
                    OwnerId = projects[i].OwnerId,
                    Priority = projects[i].Priority,
                    StartedAt = projects[i].StartedAt,
                };
                projectsDTO.Add(projectDTO);
            }
            return new ProjectDTOsResponse(200, true, null, projectsDTO);
        }
    }
}
