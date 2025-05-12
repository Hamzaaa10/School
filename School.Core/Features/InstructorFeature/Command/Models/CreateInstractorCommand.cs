using MediatR;
using Microsoft.AspNetCore.Http;
using School.Core.Bases;

namespace School.Core.Features.InstructorFeature.Command.Models
{
    public class CreateInstractorCommand : IRequest<Response<string>>
    {
        public string IName { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public double Salary { get; set; }
        public IFormFile? Image { get; set; }
        public int DID { get; set; }


    }
}
