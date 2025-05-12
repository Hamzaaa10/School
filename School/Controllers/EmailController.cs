using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.Email.Commands.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    public class EmailController : AppControllerBase
    {
        [HttpPost(Router.EmailRouting.SendEmail)]

        /* [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status401Unauthorized)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> SendEmail([FromForm] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}