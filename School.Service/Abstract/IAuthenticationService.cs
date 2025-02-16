using School.Data.Helpers;
using School.Data.Models.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace School.Service.Abstract
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResponse> GetJWTtoken(User user);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<JwtAuthResponse> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string AccessToken);
    }
}
