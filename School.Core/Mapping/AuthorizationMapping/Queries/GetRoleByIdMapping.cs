using School.Core.Features.Authorization.Quiery.Responses;
using School.Data.Models.Identity;

namespace School.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<ApplicationRole, GetRoleByIdResponse>();
        }
    }
}
