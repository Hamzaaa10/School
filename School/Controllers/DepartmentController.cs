using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.DepartmentFeature.Command.Models;
using School.Core.Features.DepartmentFeature.Query.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetAllDepartmentAsync()
        {

            var Response = await Mediator.Send(new GetAllDepartmentsQuery());
            return NewResult(Response);
        }
        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            var Response = await Mediator.Send(new GetDepartmentByIdQuery(id));
            return NewResult(Response);
        }

        [HttpPost(Router.DepartmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpPut(Router.DepartmentRouting.Update)]
        public async Task<IActionResult> Edit([FromBody] EditDepartmentCommand command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }
        [HttpDelete(Router.DepartmentRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteDepartmentCommand(id));
            return NewResult(Response);
        }
    }
}
