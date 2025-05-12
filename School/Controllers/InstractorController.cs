using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.InstructorFeature.Command.Models;
using School.Core.Features.InstructorFeature.Query.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]

    public class InstractorController : AppControllerBase
    {

        [HttpGet(Router.InstractorRouting.List)]
        public async Task<IActionResult> GetAllInstractors()
        {

            var Response = await Mediator.Send(new GetInstractorsQuery());
            return NewResult(Response);
        }

        [HttpGet(Router.InstractorRouting.GetByID)]
        public async Task<IActionResult> GetById(int id)
        {
            var Response = await Mediator.Send(new GetInstractorByIdQuery(id));
            return NewResult(Response);
        }
        [HttpPost(Router.InstractorRouting.Create)]
        public async Task<IActionResult> Create([FromForm] CreateInstractorCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpPut(Router.InstractorRouting.Update)]
        public async Task<IActionResult> Edit([FromForm] EditInstractorCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpDelete(Router.InstractorRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteInstractorCommand(id));
            return NewResult(Response);
        }
    }
}
