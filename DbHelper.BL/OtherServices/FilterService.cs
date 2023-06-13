using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.DbHelper;
using DbHelper.DAL.Entities.DTOs;

namespace DbHelper.BL.OtherServices
{
    public class FilterService
    {
        private readonly ProjectRepository _projectRepository;
        public FilterService(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<List<Project>> GetEmployeeProjects(int employeeId, DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            List<Project> projects = await _projectRepository.GetEmployeeProjects(employeeId);
            if (startDate.HasValue && endDate.HasValue)
            {
                projects = (List<Project>)projects.Where(p => p.StartedAt >= startDate.Value && p.CompletedAt <= endDate.Value);
            }

            if (priority.HasValue)
            {
                projects = (List<Project>)projects.Where(p => p.Priority == priority.Value);
            }
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "name":
                        projects = (List<Project>)projects.OrderBy(p => p.Name);
                        break;
                    case "createdDate":
                        projects = (List<Project>)projects.OrderBy(p => p.StartedAt);
                        break;
                    default:
                        projects = (List<Project>)projects.OrderBy(p => p.Id);
                        break;
                }
            }

            return projects.ToList();
        }

        public async Task<List<Project>> GetOwnProjects(int employeeId, DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            var projects = await _projectRepository.GetOwningProject(employeeId);

            if (startDate.HasValue && endDate.HasValue)
            {
                projects = (List<Project>)projects.Where(p => p.StartedAt >= startDate.Value && p.CompletedAt <= endDate.Value);
            }

            if (priority.HasValue)
            {
                projects = (List<Project>)projects.Where(p => p.Priority == priority.Value);
            }
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "name":
                        projects = (List<Project>)projects.OrderBy(p => p.Name);
                        break;
                    case "createdDate":
                        projects = (List<Project>)projects.OrderBy(p => p.StartedAt);
                        break;
                    default:
                        projects = (List<Project>)projects.OrderBy(p => p.Id);
                        break;
                }
            }

            return projects.ToList();
        }
        public async Task<List<Project>> GetAllProjects(DateTime? startDate, DateTime? endDate, int? priority, string? sortBy)
        {
            var projects = await _projectRepository.GetAllAsync();

            if (startDate.HasValue && endDate.HasValue)
            {
                projects = projects.Where(p => p.StartedAt >= startDate.Value && p.CompletedAt <= endDate.Value);
            }

            if (priority.HasValue)
            {
                projects = projects.Where(p => p.Priority == priority.Value);
            }
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "name":
                        projects = projects.OrderBy(p => p.Name);
                        break;
                    case "createdDate":
                        projects = projects.OrderBy(p => p.StartedAt);
                        break;
                    default:
                        projects = projects.OrderBy(p => p.Id);
                        break;
                }
            }

            return projects.ToList();
        }
    }
}
