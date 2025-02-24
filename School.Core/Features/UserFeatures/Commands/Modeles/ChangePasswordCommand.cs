using MediatR;
using School.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace School.Core.Features.UserFeatures.Commands.Modeles
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
