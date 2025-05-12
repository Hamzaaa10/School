using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.StudentSubjectFeature.Command.Models;
using School.Core.Features.StudentSubjectFeature.Query.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    public class StudentSubjectController : AppControllerBase
    {
        [HttpGet(Router.StudentSubjectRouting.List)]
        public async Task<IActionResult> getStudentSubjects(int id)
        {
            var Response = await Mediator.Send(new GetStudentSubjectsQuery(id));
            return NewResult(Response);
        }
        [HttpPost(Router.StudentSubjectRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddSubjectToStudentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpPut(Router.StudentSubjectRouting.Update)]
        public async Task<IActionResult> Edit([FromBody] EditStudentSubjectCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpDelete(Router.StudentSubjectRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteSubjectFromStudentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
    }
}
