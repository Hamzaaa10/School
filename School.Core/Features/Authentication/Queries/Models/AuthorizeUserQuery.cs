using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Authentication.Queries.Models
{
    public class AuthorizeUserQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }

}
