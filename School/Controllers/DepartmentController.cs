using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Features.Department.Quieries.Models;
using School.Data.AppMetaData;

namespace School.Api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            var Response = await Mediator.Send(new GetDepartmentByIdQuery(id));
            return NewResult(Response);
        }
    }
}
