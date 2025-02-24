using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Core.Bases;
using School.Core.Features.UserFeatures.Commands.Modeles;
using School.Data.Models.Identity;

namespace School.Core.Features.UserFeatures.Commands.Hundllers
{
    public class UsesHundllers : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
                                                , IRequestHandler<EditUserCommand, Response<string>>
                                                , IRequestHandler<DeleteUserCommand, Response<string>>
                                                , IRequestHandler<ChangePasswordCommand, Response<string>>

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

            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            await _userManager.AddToRoleAsync(NewUser, "User");
            return Created("Added succsesfully");

        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var OldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (OldUser == null) return NotFound<string>("this user don't exists");
            var NewUser = _mapper.Map(request, OldUser);

            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == NewUser.UserName && x.Id != NewUser.Id);
            if (userByUserName != null) return BadRequest<string>("username is unique");

            var result = await _userManager.UpdateAsync(NewUser);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success("Editing succsesfully");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var OldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (OldUser == null) return NotFound<string>("this user don't exists");
            var result = await _userManager.DeleteAsync(OldUser);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success("Deleting succsesfully");
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null) return NotFound<string>("this user don't exists");
            var result = await _userManager.ChangePasswordAsync(User, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success("changed");
        }
    }
}
