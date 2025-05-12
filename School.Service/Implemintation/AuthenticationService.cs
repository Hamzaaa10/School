using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School.Data.Helpers;
using School.Data.Models.Identity;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Data;
using School.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace School.Service.Implemintation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Jwtsettings _jwtsettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly AppDbContext _appDBContext;

        // private readonly IEncryptionProvider _encryptionProvider;


        public AuthenticationService(Jwtsettings jwtsettings, IRefreshTokenRepository refreshTokenRepository, UserManager<User> userManager, IEmailService emailService, AppDbContext appDbContext)
        {
            _jwtsettings = jwtsettings;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _emailService = emailService;
            _appDBContext = appDbContext;
        }
        public async Task<List<Claim>> GetClaims(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var UserClaims = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>() {
                new Claim(nameof(UserClaimsModel.Email), user.Email)  ,
                new Claim(nameof(UserClaimsModel.UserName), user.UserName),
                new Claim(nameof(UserClaimsModel.PhoneNumber), user.PhoneNumber),
                new Claim(nameof(UserClaimsModel.Id), user.Id.ToString())
                };
            claims.AddRange(UserClaims);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private string GeneratetRefreshToken()
        {

            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            var refreshToken = Convert.ToBase64String(randomNumber);
            return refreshToken;
        }
        private RefreshToken GetRefreshToken(string username, string refreshToken)
        {

            var Refreshtoken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtsettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = refreshToken
            };

            return Refreshtoken;
        }
        private async Task<(JwtSecurityToken, string)> GenerateJWTToken(User user)
        {
            var jwtToken = new JwtSecurityToken(
             issuer: _jwtsettings.Issuer,
             audience: _jwtsettings.Audience,
             claims: await GetClaims(user),
             notBefore: DateTime.Now,
             expires: DateTime.Now.AddMinutes(_jwtsettings.AccessTokenExpireDate),
             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtsettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
             );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        public async Task<JwtAuthResponse> GetJWTtoken(User user)
        {

            var (jwtToken, accessToken) = await GenerateJWTToken(user);
            var stringrefreshtoken = GeneratetRefreshToken();
            var userrefreshtoken = new UserRefreshToken
            {
                UserId = user.Id,
                JwtId = jwtToken.Id,
                IsRevoked = false,
                IsUsed = false,
                ExpiryDate = DateTime.UtcNow.AddDays(_jwtsettings.RefreshTokenExpireDate),
                AddedTime = DateTime.UtcNow,
                Token = accessToken,
                RefreshToken = stringrefreshtoken,
            };
            await _refreshTokenRepository.AddAsync(userrefreshtoken);


            var gwtResult = new JwtAuthResponse
            {
                AccessToken = accessToken,
                refreshToken = GetRefreshToken(user.UserName, stringrefreshtoken)
            };

            return (gwtResult);

        }
        public JwtSecurityToken ReadJWTToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }

        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtsettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtsettings.Issuer },
                ValidateIssuerSigningKey = _jwtsettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtsettings.Secret)),
                ValidAudience = _jwtsettings.Audience,
                ValidateAudience = _jwtsettings.ValidateAudience,
                ValidateLifetime = _jwtsettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "InvalidToken";
                }

                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("AlgorithmIsWrong", null);
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("TokenIsNotExpired", null);
            }

            //Get User

            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.Id)).Value;
            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking()
                                             .FirstOrDefaultAsync(x => x.Token == accessToken &&
                                                                     x.RefreshToken == refreshToken &&
                                                                     x.UserId == int.Parse(userId));
            if (userRefreshToken == null)
            {
                return ("RefreshTokenIsNotFound", null);
            }

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("RefreshTokenIsExpired", null);
            }
            var expirydate = userRefreshToken.ExpiryDate;
            return (userId, expirydate);
        }

        public async Task<JwtAuthResponse> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        {
            var (jwtSecurityToken, newaccessToken) = await GenerateJWTToken(user);
            var response = new JwtAuthResponse();
            var refreshTokenResult = new RefreshToken();
            response.AccessToken = newaccessToken;
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.UserName)).Value;
            refreshTokenResult.TokenString = refreshToken;
            refreshTokenResult.ExpireAt = (DateTime)expiryDate;
            response.refreshToken = refreshTokenResult;
            return response;

        }

        /* public Task<string> ConfirmResetPassword(string AccessToken)
         {
             throw new NotImplementedException();
         }*/

        public async Task<string> ConfirmEmail(int UserId, string code)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);
            if (!confirmEmail.Succeeded)
                return "ErrorWhenConfirmEmail";
            return "Success";
        }

        public async Task<string> SendResetPasswordCode(string Email)
        {
            var trans = await _appDBContext.Database.BeginTransactionAsync();
            try
            {
                var User = await _userManager.FindByEmailAsync(Email);
                if (User == null) return "UserNotFound";

                var chars = "0123456789";
                var random = new Random();
                var Code = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                User.Code = Code;
                var UpdateResult = await _userManager.UpdateAsync(User);
                if (!UpdateResult.Succeeded) return "Error in Update User";
                string message = "Code for Reset Password  " + Code;
                await _emailService.SendEmailAsync(Email, message, "ResetPassword");
                await trans.CommitAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

    }
}

