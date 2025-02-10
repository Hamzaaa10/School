using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Core.Bases;
using School.Core.Features.UserFeatures.Quieries.Models;
using School.Core.Features.UserFeatures.Quieries.Responses;
using School.Core.Wrappers;
using School.Core.Wrappers.SchoolProject.Core.Wrappers;
using School.Data.Models.Identity;

namespace School.Core.Features.UserFeatures.Quieries.Hundllers
{
    public class UserHundllers :
        ResponseHandler, IRequestHandler<GetUsersPaginatedQuery, PaginatedResult<GetUsersPaginatedResponse>>
                       , IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserHundllers(UserManager<User> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<GetUsersPaginatedResponse>> Handle(GetUsersPaginatedQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedUsers = await _mapper.ProjectTo<GetUsersPaginatedResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedUsers;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<GetUserByIdResponse>("user not found");
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);

        }
    }
}
