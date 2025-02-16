using MediatR;
using School.Core.Bases;
using School.Core.Features.Authentication.Queries.Models;
using School.Service.Abstract;

namespace School.Core.Features.Authentication.Queries.Hundller
{
    public class AuthenticationQueryHandler : ResponseHandler,
       IRequestHandler<AuthorizeUserQuery, Response<string>>


    {

        private readonly IAuthenticationService _authenticationService;
        public AuthenticationQueryHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }



        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
                return Success(result);
            return Unauthorized<string>();
        }
    }
}