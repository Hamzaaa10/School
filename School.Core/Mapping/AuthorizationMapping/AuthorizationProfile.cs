using AutoMapper;

namespace School.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetAllRolesMapping();
            GetRoleByIdMapping();
        }
    }

}
