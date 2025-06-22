using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduflowBackend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class StudentProfileRepository(AppDbContext context)
    : BaseRepository<ProfileStudent>(context), IStudentProfileRepository
{
    public async Task<ProfileStudent?> FindByEmailAsync(Email email)
    {
        return await Context.Set<ProfileStudent>()
            .FirstOrDefaultAsync(p => p.Email.Value == email.Value);
    }
}