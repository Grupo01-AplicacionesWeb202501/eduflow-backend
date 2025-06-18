using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;
using AcademicStaffContext.AcademicStaff.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AcademicStaffContext.Shared.Infraestructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet de Teacher
        public DbSet<Teacher> Teachers => Set<Teacher>();

        // DbSet de Department
        public DbSet<Department> Departments => Set<Department>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Teacher
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.OwnsOne(t => t.AcademicDegree, ad =>
                {
                    ad.Property(p => p.Value).HasColumnName("AcademicDegree").IsRequired();
                    ad.Property(p => p.Value).HasMaxLength(50);
                });

                entity.Property(t => t.Speciality).HasMaxLength(100);

                // Aquí podrías mapear la relación con Department si la tienes
                //entity.HasOne(t => t.Department)
                //      .WithMany()
                //      .HasForeignKey(t => t.DepartmentId);
            });

            // Configuración para Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments"); // Nombre de la tabla en MySQL

                entity.HasKey(d => d.Id);

                entity.Property(d => d.NameDepartment)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(d => d.DescriptionDepartment)
                      .HasMaxLength(250);

                entity.Property(d => d.Email)
                      .HasMaxLength(100);

                entity.Property(d => d.PhoneNumber)
                      .HasMaxLength(20);
            });
        }
    }
}
