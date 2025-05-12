using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.DepartmentSubjectFeatures.Command.Requests;
using School.Core.Features.DepartmentSubjectFeatures.Query.Requests;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    public class DepartmentSubjectController : AppControllerBase
    {
        [HttpGet(Router.DepartmentSubjectRouting.List)]
        public async Task<IActionResult> GetSubjectInDepartmentListAsync(int id)
        {
            var Response = await Mediator.Send(new GetSubjectsInDepartmentQuery(id));
            return NewResult(Response);
        }
        [HttpPost(Router.DepartmentSubjectRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddSubjectToDepartmentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }

        [HttpDelete(Router.DepartmentSubjectRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteSubjectFromDepartmentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
    }
}
