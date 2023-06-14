using DbHelper.BL.OtherServices;
using DbHelper.DAL.Common.ProjectResponses;
using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.DTOs;
using DbHelper.DAL.Entities.Enums;
using DbHelper.DAL.Entities.Requests.ProjectRequests;

namespace DbHelper.BL.ProjectBL
{
    public class TaskManager
    {
        private readonly IRepository<ProjectTask> _taskRepository;
        private readonly GetUserService _getUserService;
        private readonly ProjectRepository _projectRepository;
        public TaskManager(IRepository<ProjectTask> taskRepository, GetUserService getUserService, ProjectRepository projectRepository)
        {
            _taskRepository = taskRepository;
            _getUserService = getUserService;
            _projectRepository = projectRepository;
        }
        public async Task<TaskResponse> Create(CreateTaskRequest request)
        {
            var user = await _getUserService.GetCurrentUser();
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            var projects = await _projectRepository.GetOwningProject(user.Id);
            if (!projects.Contains(project))
            {
                return new TaskResponse(400, false, "Вы не являетесь владельцем данного проекта и не можете" +
                    " добавлять в него задачи!", 0);
            }
            var task = new ProjectTask
            {
                ProjectId = request.ProjectId,
                Comment = request.Comment,
                ExecutorId = request.ExecutorId,
                Name = request.Name,
                OwnerId = user.Id,
                Priority = request.Priority,
                Status = (TaskEnum)request.Status,
            };
            await _taskRepository.AddAsync(task);
            return new TaskResponse(200, true, "Вы успешно создали задачу!", task.Id);
        }
        public async Task<TaskResponse> Update(UpdateTaskRequest request)
        {
            var user = await _getUserService.GetCurrentUser();
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            var projects = await _projectRepository.GetOwningProject(user.Id);
            if (!projects.Contains(project))
            {
                return new TaskResponse(400, false, "Вы не являетесь владельцем данного проекта и не можете" +
                    " добавлять в него задачи!", 0);
            }
            var task = await _taskRepository.GetByIdAsync(request.Id);
            task.Status = (TaskEnum)request.Status;
            task.ProjectId = request.ProjectId;
            task.Comment = request.Comment;
            task.ExecutorId = request.ExecutorId;
            task.Name = request.Name;
            task.OwnerId = user.Id;
            task.Priority = request.Priority;
            await _taskRepository.UpdateAsync(task);
            return new TaskResponse(200, true, "Вы успешно обновили задачу!", request.Id);
        }
        public async Task<TaskResponse> UpdateStatus(int taskId, int status)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            task.Status = (TaskEnum)status;
            await _taskRepository.UpdateAsync(task);
            return new TaskResponse(200, true, "Вы успешно обновили статус задачи!", taskId);
        }
        public async Task<TaskDTOsResponse> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllAsync();
            var taskDTOs = new List<TaskDTO>();
            foreach (var task in tasks)
            {
                var taskDTO = new TaskDTO
                {
                    Comment = task.Comment,
                    ExecutorId = task.ExecutorId,
                    Id = task.Id,
                    Name = task.Name,
                    OwnerId = task.OwnerId,
                    Priority = task.Priority,
                    ProjectId = task.ProjectId,
                    Status = task.Status,
                };
                taskDTOs.Add(taskDTO);
            }
            return new TaskDTOsResponse(200, true, null, taskDTOs);
        }
        public async Task<TaskDTOsResponse> GetAllOwningTasks(int managerId)
        {
            var tasks = await _taskRepository.GetAllAsync();
            var managerTasks = tasks.Where(t => t.OwnerId == managerId).ToList();

            var taskDTOs = new List<TaskDTO>();
            foreach (var task in managerTasks)
            {
                var taskDTO = new TaskDTO
                {
                    Comment = task.Comment,
                    ExecutorId = task.ExecutorId,
                    Id = task.Id,
                    Name = task.Name,
                    OwnerId = task.OwnerId,
                    Priority = task.Priority,
                    ProjectId = task.ProjectId,
                    Status = task.Status,
                };
                taskDTOs.Add(taskDTO);
            }
            return new TaskDTOsResponse(200, true, null, taskDTOs);
        }
        public async Task<TaskDTOsResponse> GetAllExecutingTasks(int executorId)
        {
            var tasks = await _taskRepository.GetAllAsync();
            var executorTasks = tasks.Where(t => t.ExecutorId == executorId).ToList();

            var taskDTOs = new List<TaskDTO>();
            foreach (var task in executorTasks)
            {
                var taskDTO = new TaskDTO
                {
                    Comment = task.Comment,
                    ExecutorId = task.ExecutorId,
                    Id = task.Id,
                    Name = task.Name,
                    OwnerId = task.OwnerId,
                    Priority = task.Priority,
                    ProjectId = task.ProjectId,
                    Status = task.Status,
                };
                taskDTOs.Add(taskDTO);
            }
            return new TaskDTOsResponse(200, true, null, taskDTOs);
        }
        public async Task<TaskDTOsResponse> GetAllProjectTasks(int projectId)
        {
            var tasks = await _taskRepository.GetAllAsync();
            var projectTasks = tasks.Where(t => t.ProjectId == projectId).ToList();

            var taskDTOs = new List<TaskDTO>();
            foreach (var task in projectTasks)
            {
                var taskDTO = new TaskDTO
                {
                    Comment = task.Comment,
                    ExecutorId = task.ExecutorId,
                    Id = task.Id,
                    Name = task.Name,
                    OwnerId = task.OwnerId,
                    Priority = task.Priority,
                    ProjectId = task.ProjectId,
                    Status = task.Status,
                };
                taskDTOs.Add(taskDTO);
            }
            return new TaskDTOsResponse(200, true, null, taskDTOs);
        }
        public async Task<TaskDTOResponse> GetTaskById(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task == null)
            {
                return new TaskDTOResponse(404, true, "Задача с таким айди не существует!", null);
            }
            var taskDTO = new TaskDTO
            {
                Comment = task.Comment,
                ExecutorId = task.ExecutorId,
                Id = task.Id,
                Name = task.Name,
                OwnerId = task.OwnerId,
                Priority = task.Priority,
                ProjectId = task.ProjectId,
                Status = task.Status,
            };
            return new TaskDTOResponse(200, true, null, taskDTO);
        }
    }
}
