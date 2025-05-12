using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.SubjectFeatures.Command.Models;
using School.Core.Features.SubjectFeatures.Query.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    public class SubjectController : AppControllerBase
    {
        [HttpGet(Router.SubjectRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetAllSubjectsQuery query)
        {
            var Response = await Mediator.Send(query);
            return Ok(Response);
        }
        [HttpGet(Router.SubjectRouting.GetByID)]
        public async Task<IActionResult> GetById(int id)
        {
            var Response = await Mediator.Send(new GetSubjectByIdQuery(id));
            return NewResult(Response);
        }
        [HttpPost(Router.SubjectRouting.Create)]
        public async Task<IActionResult> Create([FromForm] CreateSubjectCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpPut(Router.SubjectRouting.Update)]
        public async Task<IActionResult> Edit([FromForm] EditSubjectCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpDelete(Router.SubjectRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteSubjectCommand(id));
            return NewResult(Response);
        }
    }
}
