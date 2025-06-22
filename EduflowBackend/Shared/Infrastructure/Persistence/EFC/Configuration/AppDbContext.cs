using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EduflowBackend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ProfileStudent>(student =>
        {
            student.HasKey(p => p.Id);
            student.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            student.OwnsOne(p => p.FullName, fn =>
            {
                fn.WithOwner().HasForeignKey("id");
                fn.Property(f => f.FirstName).HasColumnName("first_name").IsRequired();
                fn.Property(f => f.LastName).HasColumnName("last_name").IsRequired();
                fn.Ignore(f => f.Value);
            });

            student.OwnsOne(p => p.Email, e =>
            {
                e.WithOwner().HasForeignKey("id");
                e.Property(e => e.Value).HasColumnName("email").IsRequired();
            });

            student.OwnsOne(p => p.Career, c =>
            {
                c.WithOwner().HasForeignKey("id");
                c.Property(c => c.Value).HasColumnName("career").IsRequired();
            });

            student.OwnsOne(p => p.Cycle, c =>
            {
                c.WithOwner().HasForeignKey("id");
                c.Property(c => c.Value).HasColumnName("cycle").IsRequired();
            });
        });

        builder.Entity<TeacherProfile>(teacher =>
        {
            teacher.HasKey(p => p.Id);
            teacher.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            teacher.OwnsOne(p => p.FullName, fn =>
            {
                fn.WithOwner().HasForeignKey("id");
                fn.Property(f => f.FirstName).HasColumnName("first_name").IsRequired();
                fn.Property(f => f.LastName).HasColumnName("last_name").IsRequired();
                fn.Ignore(f => f.Value);
            });

            teacher.OwnsOne(p => p.Email, e =>
            {
                e.WithOwner().HasForeignKey("id");
                e.Property(e => e.Value).HasColumnName("email").IsRequired();
            });

            teacher.OwnsOne(p => p.Subject, s =>
            {
                s.WithOwner().HasForeignKey("id");
                s.Property(s => s.Value).HasColumnName("subject").IsRequired();
            });
        });

        builder.UseSnakeCaseNamingConvention();
    }

    public DbSet<ProfileStudent> ProfileStudents => Set<ProfileStudent>();
    public DbSet<TeacherProfile> TeacherProfiles => Set<TeacherProfile>();
}