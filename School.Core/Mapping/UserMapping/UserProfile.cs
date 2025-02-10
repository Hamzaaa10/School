using AutoMapper;

namespace School.Core.Mapping.UserMapping
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
            GetUsersPaginatedMapping();
            GetUserByIdMapping();
        }
    }
}
