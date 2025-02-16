using Microsoft.EntityFrameworkCore;
using School.Data.Models.Identity;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;

namespace School.Infrastracture.ImplemintationRepository
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        private readonly DbSet<UserRefreshToken> _userRefreshTokens;

        public RefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
        {

            _userRefreshTokens = dbContext.Set<UserRefreshToken>();
        }
    }
}
