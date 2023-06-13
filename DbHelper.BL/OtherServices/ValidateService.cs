using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.DbHelper;

namespace DbHelper.BL.OtherServices
{
    public class ValidateService
    {
        private readonly GetUserService _getUserService;
        private readonly ProjectRepository _projectRepository;
        public ValidateService(GetUserService getUserService, ProjectRepository projectRepository)
        {
            _getUserService = getUserService;
            _projectRepository = projectRepository;
        }
        public async Task<bool> GetUpdateProjectPerms(int projectId)
        {
            var user = await _getUserService.GetCurrentUser();
            var roles = await _getUserService.GetCurrentUserRoles();
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (user.Id != project.OwnerId)
            {
                if (roles.Contains("Admin"))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        public async Task<bool> GetProjectPerms(int projectId)
        {
            var user = await _getUserService.GetCurrentUser();
            var roles = await _getUserService.GetCurrentUserRoles();
            var project = await _projectRepository.GetByIdAsync(projectId);
            var projectEmployees = await _projectRepository.GetProjectEmployees(projectId);
            if (user.Id != project.OwnerId)
            {
                if (roles.Contains("Admin"))
                {
                    return true;
                }
                else if (projectEmployees.Contains(user))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
