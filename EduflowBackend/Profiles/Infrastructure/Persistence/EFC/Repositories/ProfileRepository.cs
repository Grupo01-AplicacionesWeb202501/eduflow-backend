using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduflowBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Profile repository implementation
/// </summary>
/// <param name="context">Application DB context</param>
public class ProfileRepository(AppDbContext context)
    : BaseRepository<Profile>(context), IProfileRepository
{
    /// <inheritdoc />
    public async Task<Profile?> FindByEmailAsync(Email email)
    {
        return await Context.Set<Profile>()
            .FirstOrDefaultAsync(p => p.Email.Address == email.Address);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Profile>> ListByUserTypeAsync(UserType userType)
    {
        return await Context.Set<Profile>()
            .Where(p => p.UserType.Value == userType.Value)
            .ToListAsync();
    }
}