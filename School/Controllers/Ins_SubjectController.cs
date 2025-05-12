using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.Ins_SubjectFeature.Command.Models;
using School.Core.Features.Ins_SubjectFeature.Query.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    public class Ins_SubjectController : AppControllerBase
    {
        [HttpGet(Router.Ins_SubjectRouting.List)]
        public async Task<IActionResult> getSubjectsWithInstractor(int id)
        {
            var Response = await Mediator.Send(new GetSubjectsAttatchedWithInstractorQuery(id));
            return NewResult(Response);
        }
        [HttpPost(Router.Ins_SubjectRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddSubjectToInstractorCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }

        [HttpDelete(Router.Ins_SubjectRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteIns_SubjectCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
    }
}
