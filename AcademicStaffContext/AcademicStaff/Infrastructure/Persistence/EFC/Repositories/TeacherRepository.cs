using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;
using AcademicStaffContext.AcademicStaff.Domain.Repositories;
using AcademicStaffContext.Shared.Infraestructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AcademicStaffContext.AcademicStaff.Infrastructure.Persistence.EFC.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetAllAsync() =>
        await _context.Teachers.ToListAsync();

    public async Task<Teacher?> GetByIdAsync(Guid id) =>
        await _context.Teachers.FindAsync(id);

    public async Task AddAsync(Teacher teacher) =>
        await _context.Teachers.AddAsync(teacher);

    public void Update(Teacher teacher) =>
        _context.Teachers.Update(teacher);

    public void Delete(Teacher teacher) =>
        _context.Teachers.Remove(teacher);
}