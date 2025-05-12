using MediatR;
using School.Core.Bases;
using School.Core.Features.Authentication.Queries.Models;
using School.Service.Abstract;

namespace School.Core.Features.Authentication.Queries.Hundller
{
    public class AuthenticationQueryHandler : ResponseHandler,
       IRequestHandler<AuthorizeUserQuery, Response<string>>,
       IRequestHandler<ConfirmEmailQuery, Response<string>>


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

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>("ErrorWhenConfirmEmail");
            return Success<string>("ConfirmEmailDone");
        }
    }
}