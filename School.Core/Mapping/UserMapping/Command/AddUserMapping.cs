using School.Core.Features.UserFeatures.Commands.Modeles;
using School.Data.Models.Identity;

namespace School.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>();
        }

    }
}




