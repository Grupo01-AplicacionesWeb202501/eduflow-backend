using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;

namespace AcademicStaffContext.AcademicStaff.Domain.Repositories;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(Guid id);
    Task AddAsync(Teacher teacher);
    void Update(Teacher teacher);
    void Delete(Teacher teacher);
}