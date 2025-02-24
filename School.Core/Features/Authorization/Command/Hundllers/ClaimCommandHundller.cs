using MediatR;
using School.Core.Bases;
using School.Core.Features.Authorization.Command.Modeles;
using School.Service.Abstract;

namespace School.Core.Features.Authorization.Command.Hundllers
{
    public class ClaimCommandHundller : ResponseHandler,
                                                    IRequestHandler<UpdateUserClaimCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public ClaimCommandHundller(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("UserIsNotFound");
                case "FailedToRemoveOldClaims": return BadRequest<string>("FailedToRemoveOldClaims");
                case "FailedToAddNewClaims": return BadRequest<string>("FailedToAddNewClaims");
                case "FailedToUpdateUserClaims": return BadRequest<string>("FailedToUpdateUserClaims");
            }
            return Success<string>("Success");

        }
    }
}
