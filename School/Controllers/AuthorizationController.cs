using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.Authorization.Command.Modeles;
using School.Core.Features.Authorization.Quiery.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.AuthorizationRouting.Create)]
        //[AllowAnonymous]
        //[Authorize("User")]

        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpPut(Router.AuthorizationRouting.Update)]

        public async Task<IActionResult> Update([FromForm] EditRoleCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpDelete(Router.AuthorizationRouting.Delete)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Response = await Mediator.Send(new DeleteRoleCommand(id));
            return NewResult(Response);
        }
        [HttpGet(Router.AuthorizationRouting.GetAll)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var Response = await Mediator.Send(new GetAllRolesQuery());
            return NewResult(Response);
        }
        [HttpGet(Router.AuthorizationRouting.GetById)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var Response = await Mediator.Send(new GetRoleByIdQuery(id));
            return NewResult(Response);
        }
        [HttpGet(Router.AuthorizationRouting.ManageUserRole)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int id)
        {
            var Response = await Mediator.Send(new ManageUserRoleQuery(id));
            return NewResult(Response);
        }
        [HttpPut(Router.AuthorizationRouting.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AuthorizationRouting.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int id)
        {
            var Response = await Mediator.Send(new ManageUserClaimsQuery(id));
            return NewResult(Response);
        }
        [HttpPut(Router.AuthorizationRouting.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
