using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.StudentFeatures.Command.Models;
using School.Core.Features.StudentFeatures.Queries.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StudentController : AppControllerBase
    {


        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentListAsync()
        {

            var Response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(Response);
        }
        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var Response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(Response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        [Authorize(policy: "CreateStudent")]

        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpPut(Router.StudentRouting.Update)]
        [Authorize(policy: "EditStudent")]

        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        [Authorize(policy: "DeleteStudent")]

        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(Response);
        }

        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentListPaginationQuery query)
        {

            var Response = await Mediator.Send(query);
            return Ok(Response);
        }

    }
}

