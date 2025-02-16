using School.Data.Models.Identity;
using School.Infrastracture.Bases;

namespace School.Infrastracture.AbstractRepository
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
