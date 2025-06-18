using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;
using AcademicStaffContext.AcademicStaff.Domain.Repositories;
using AcademicStaffContext.Shared.Infraestructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AcademicStaffContext.AcademicStaff.Infrastructure.Persistence.EFC.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync() => 
            await _context.Departments.ToListAsync();

        public async Task<Department?> GetByIdAsync(Guid id) =>
        await _context.Departments.FindAsync(id);

        public async Task AddAsync(Department department) =>
            await _context.Departments.AddAsync(department);

        public void Update(Department department) =>
            _context.Departments.Update(department);

        public void Delete(Department department) =>
            _context.Departments.Remove(department);
    }
}
