using DbHelper.DAL.Common;

namespace DbHelper.DAL.Entities.Identity
{
    public class AuthResponse : Response
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AuthResponse(int statusCode, bool success, string message, string accessToken, string refreshToken) : base(statusCode, success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
