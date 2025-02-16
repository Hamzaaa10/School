using MediatR;
using School.Core.Bases;
using School.Data.Helpers;

namespace School.Core.Features.Authentication.Command.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}