﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Core.Bases;
using School.Core.Features.Authentication.Command.Models;
using School.Data.Helpers;
using School.Data.Models.Identity;
using School.Service.Abstract;

namespace School.Core.Features.Authentication.Command.Hundellers
{
    public class AuthenticationCommandHundller : ResponseHandler,
         IRequestHandler<SignInCommand, Response<JwtAuthResponse>>,
         IRequestHandler<RefreshTokenCommand, Response<JwtAuthResponse>>,
         IRequestHandler<ResetPasswordCommand, Response<string>>


    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthenticationCommandHundller(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authenticationService, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
            _roleManager = roleManager;
        }
        public async Task<Response<JwtAuthResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return NotFound<JwtAuthResponse>("No user found such that username");
            var SignInresult = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!SignInresult) return BadRequest<JwtAuthResponse>("PasswordNotCorrect");
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResponse>("EmailNotConfirmed");
            var accesstoken = await _authenticationService.GetJWTtoken(user);
            return Success(accesstoken);

        }

        public async Task<Response<JwtAuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJWTToken(request.AccessToken);
            var userIdAndExpireDate = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthResponse>("Algorithm Is Wrong");
                case ("TokenIsValid", null): return Unauthorized<JwtAuthResponse>("Token Is Valid");
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthResponse>("RefreshToken Is Not Found");
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthResponse>("RefreshToken Is Expired");
            }
            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResponse>();
            }
            var result = await _authenticationService.GetRefreshToken(user, jwtToken, expiryDate, request.RefreshToken);
            return Success(result);

        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SendResetPasswordCode(request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("UserIsNotFound");
                case "ErrorInUpdateUser": return BadRequest<string>("TryAgainInAnotherTime");
                case "Failed": return BadRequest<string>("TryAgainInAnotherTime");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("TryAgainInAnotherTime");
            }
        }
    }
}
