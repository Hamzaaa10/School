using MediatR;
using School.Core.Bases;
using School.Data.Helpers;
using System.ComponentModel.DataAnnotations;

namespace School.Core.Features.Authentication.Command.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
