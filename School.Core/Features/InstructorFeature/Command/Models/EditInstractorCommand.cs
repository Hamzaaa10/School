using MediatR;
using Microsoft.AspNetCore.Http;
using School.Core.Bases;

namespace School.Core.Features.InstructorFeature.Command.Models
{
    public class EditInstractorCommand : IRequest<Response<string>>
    {
        public int InsId { get; set; }
        public string IName { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public double Salary { get; set; }
        public IFormFile? Image { get; set; }
        public int DID { get; set; }
    }
}
