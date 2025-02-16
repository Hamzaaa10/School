using MediatR;
using School.Core.Bases;
using School.Data.Helpers;

namespace School.Core.Features.Authentication.Command.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
