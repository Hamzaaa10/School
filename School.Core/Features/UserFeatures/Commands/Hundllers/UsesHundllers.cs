using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Core.Bases;
using School.Core.Features.UserFeatures.Commands.Modeles;
using School.Data.Models.Identity;

namespace School.Core.Features.UserFeatures.Commands.Hundllers
{
    public class UsesHundllers : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;


        public UsesHundllers(UserManager<User> userManager, IMapper mapper)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null) return BadRequest<string>("this email is exists");
            var userdb = await _userManager.FindByNameAsync(request.UserName);
            if (userdb != null) return BadRequest<string>("the username is exists");
            var NewUser = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(NewUser, request.Password);
            if (!result.Succeeded) return BadRequest<string>();

            return Success("");

        }
    }
}
