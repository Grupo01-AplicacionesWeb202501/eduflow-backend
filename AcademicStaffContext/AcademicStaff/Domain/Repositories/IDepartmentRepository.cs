


namespace AcademicStaffContext.AcademicStaff.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(Guid id);
        Task AddAsync(Department department);
        public void Update(Department department);
        public void Delete(Department department);
    }
}
