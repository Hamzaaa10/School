using MediatR;
using School.Core.Bases;

namespace School.Core.Features.UserFeatures.Commands.Modeles
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            this.Id = id;
        }
    }
}
