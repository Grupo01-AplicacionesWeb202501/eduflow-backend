using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduflowBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// EFC Repository implementation for TeacherProfile
/// </summary>
public class TeacherProfileRepository(AppDbContext context)
    : BaseRepository<TeacherProfile>(context), ITeacherProfileRepository
{
    public async Task<TeacherProfile?> FindByEmailAsync(Email email)
    {
        return await Context.Set<TeacherProfile>()
            .FirstOrDefaultAsync(p => p.Email.Value == email.Value);
    }
}