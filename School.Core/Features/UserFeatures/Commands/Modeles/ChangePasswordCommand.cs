using MediatR;
using School.Core.Bases;

namespace School.Core.Features.UserFeatures.Commands.Modeles
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
