using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Core.Bases;
using School.Core.Features.Authorization.Quiery.Models;
using School.Core.Features.Authorization.Quiery.Responses;
using School.Data.Models.Identity;
using School.Data.Response;
using School.Service.Abstract;

namespace School.Core.Features.Authorization.Quiery.Hundller
{
    public class AuthorizationQueryHundller : ResponseHandler,
                IRequestHandler<GetAllRolesQuery, Response<List<GetAllRolesResponse>>>,
                IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>,
                IRequestHandler<ManageUserRoleQuery, Response<ManageUserRoleResponse>>


    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AuthorizationQueryHundller(IAuthorizationService authorizationService, IMapper mapper, UserManager<User> userManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Response<List<GetAllRolesResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetAllRolesAsync();
            var MappedRules = _mapper.Map<List<GetAllRolesResponse>>(roles);
            return Success(MappedRules);


        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleByIdAsync(request.id);
            if (role == null) return BadRequest<GetRoleByIdResponse>("Role not found");
            var MappedRole = _mapper.Map<GetRoleByIdResponse>(role);
            return Success(MappedRole);
        }

        public async Task<Response<ManageUserRoleResponse>> Handle(ManageUserRoleQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<ManageUserRoleResponse>("UserNotFound");
            var result = await _authorizationService.ManageUserRoleAsync(user);
            return Success(result);
        }


    }
}
