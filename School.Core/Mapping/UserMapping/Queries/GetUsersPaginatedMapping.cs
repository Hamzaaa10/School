using School.Core.Features.UserFeatures.Quieries.Responses;
using School.Data.Models.Identity;

namespace School.Core.Mapping.UserMapping
{
    public partial class UserProfile
    {

        public void GetUsersPaginatedMapping()
        {
            CreateMap<User, GetUsersPaginatedResponse>();
        }
    }
}
