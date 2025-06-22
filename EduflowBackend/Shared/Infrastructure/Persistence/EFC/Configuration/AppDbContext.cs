using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    // 👇 REGISTRO DE AGREGADOS
    public DbSet<ProfileStudent> ProfileStudents { get; set; } = null!;
    public DbSet<TeacherProfile> TeacherProfiles { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor(); // Interceptor opcional para timestamps
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // 🐍 Convención opcional del profesor (snake_case)
        builder.UseSnakeCaseNamingConvention();
    }
}