using DbHelper.BL.AuthBL.Services;
using DbHelper.BL.Extensions;
using DbHelper.DAL.Entities.Identity;
using DbHelper.DAL.Entities.Requests.AuthRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Web.Http;

namespace DbHelper.BL.AuthBL.Managers
{
    public class AuthManager
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;
        public AuthManager(UserManager<Employee> userManager, RoleManager<Role> roleManager, TokenService tokenService,
            IConfiguration configuration) 
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }
        public async Task<AuthResponse> Authenticate([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Пользователя с такой почтой не существует!");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                throw new Exception("Неверный пароль!");
            }

            var identityRoles = new List<Role>();
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                identityRoles.Add(role);
            }
            var accessToken = _tokenService.CreateToken(user, identityRoles);
            user.RefreshToken = _configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());
            await _userManager.UpdateAsync(user);

            return new AuthResponse(200, true, "Вы успешно вошли в аккаунт!"
                , accessToken, user.RefreshToken);
        }
    }
}
