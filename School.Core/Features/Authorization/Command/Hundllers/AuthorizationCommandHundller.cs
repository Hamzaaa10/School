using MediatR;
using School.Core.Bases;
using School.Core.Features.Authorization.Command.Modeles;
using School.Service.Abstract;

namespace School.Core.Features.Authorization.Command.Hundllers
{
    public class AuthorizationCommandHundller : ResponseHandler,
                IRequestHandler<AddRoleCommand, Response<string>>,
                IRequestHandler<EditRoleCommand, Response<string>>,
                IRequestHandler<DeleteRoleCommand, Response<string>>,
                IRequestHandler<UpdateUserRoleCommand, Response<string>>

    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationCommandHundller(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }


        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddroleAsync(request.RoleName);
            if (result == "Success") return Success<string>("Role added successfully");
            return BadRequest<string>("fail to add Role");

        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateRoleAsync(request.Id, request.RoleName);
            if (result == "NotFound") return NotFound<string>($"Role With id {request.Id} was not found");
            else if (result == "Success") return Success<string>("edited successuflly");
            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);
            if (result == "NotFound") return NotFound<string>($"Role With id {request.Id} was not found");
            if (result == "Used") return BadRequest<string>(" there is some Users assign this role");
            else if (result == "Success") return Success<string>("Deleted successuflly");
            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("UserIsNotFound");
                case "FailedToRemoveOldRoles": return BadRequest<string>("FailedToRemoveOldRoles");
                case "FailedToAddNewRoles": return BadRequest<string>("FailedToAddNewRoles");
                case "FailedToUpdateUserRoles": return BadRequest<string>("FailedToUpdateUserRoles");
            }
            return Success<string>("Success");
        }
    }
}