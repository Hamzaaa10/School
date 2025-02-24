using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Core.Bases;
using School.Core.Features.Authorization.Quiery.Models;
using School.Data.Models.Identity;
using School.Data.Responses;
using School.Service.Abstract;

namespace School.Core.Features.Authorization.Quiery.Hundller
{
    internal class ClaimQueryHundller : ResponseHandler, IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResponse>>


    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;

        public ClaimQueryHundller(IAuthorizationService authorizationService, UserManager<User> userManager)
        {
            _authorizationService = authorizationService;
            _userManager = userManager;

        }

        public async Task<Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<ManageUserClaimsResponse>("UserNotFound");
            var result = await _authorizationService.ManageUserClaimsAsync(user);
            return Success(result);
        }
    }
}
