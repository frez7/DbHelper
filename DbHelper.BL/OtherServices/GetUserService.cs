using DbHelper.DAL.Data;
using DbHelper.DAL.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DbHelper.BL.OtherServices
{
    public class GetUserService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetUserService(IRepository<Employee> employeeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _employeeRepository = employeeRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Employee> GetCurrentUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int.TryParse(userId, out var id);
            var user = await _employeeRepository.GetByIdAsync(id);
            return user;

        }
        public async Task<int> GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int.TryParse(userId, out var id);
            return id;
        }
        public async Task<List<string>> GetCurrentUserRoles()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            var roles = claimsPrincipal.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            return roles;
        }
    }
}
