using DbHelper.BL.AuthBL.Managers;
using DbHelper.DAL.Entities.Identity;
using DbHelper.DAL.Entities.Requests.AuthRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbHelper.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/auth")]
    public class AuthController
    {
        private readonly AuthManager _authManager;
        public AuthController(AuthManager authManager)
        {
            _authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<AuthResponse> Login(LoginRequest request)
        {
            return await _authManager.Authenticate(request);
        }
    }
}
