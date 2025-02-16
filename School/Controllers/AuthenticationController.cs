using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.Authentication.Command.Models;
using School.Core.Features.Authentication.Queries.Models;
using Router = School.Data.AppMetaData.Router;

namespace School.Api.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.AuthenticationRouting.SignIn)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpPost(Router.AuthenticationRouting.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationRouting.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
