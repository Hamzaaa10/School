using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.UserFeatures.Commands.Modeles;
using School.Core.Features.UserFeatures.Quieries.Models;
using Router = School.Data.AppMetaData.Router;

namespace School.Api.Controllers
{

    [ApiController]

    public class UserController : AppControllerBase
    {

        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet(Router.UserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUsersPaginatedQuery query)
        {
            var Response = await Mediator.Send(query);
            return Ok(Response);
        }
        [HttpGet(Router.UserRouting.GetByID)]
        public async Task<IActionResult> GetStudentListAsync(int id)
        {
            var Response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(Response);
        }

    }
}
