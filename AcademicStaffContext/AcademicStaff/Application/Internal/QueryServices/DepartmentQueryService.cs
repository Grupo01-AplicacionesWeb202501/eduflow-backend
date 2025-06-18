using AcademicStaffContext.AcademicStaff.Application.DTO;
using AcademicStaffContext.AcademicStaff.Domain.Model.Queries;
using AcademicStaffContext.AcademicStaff.Domain.Repositories;

namespace AcademicStaffContext.AcademicStaff.Application.Internal.QueryServices
{
    public class DepartmentQueryService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentQueryService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery query)
        {
            var departments = await _repository.GetAllAsync();

            return departments.Select(MapToDto).ToList();
        }

        public async Task<DepartmentDto?> Handle(GetDepartmentByIdQuery query)
        {
            var department = await _repository.GetByIdAsync(query.DepartmentId);

            return department != null ? MapToDto(department) : null;
        }

        public async Task<List<DepartmentDto>> Handle(GetDepartmentsByNameQuery query)
        {
            var allDepartments = await _repository.GetAllAsync();
            var filtered = allDepartments
                .Where(d => d.NameDepartment.Contains(query.Name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return filtered.Select(MapToDto).ToList();
        }

        private DepartmentDto MapToDto(Department department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.NameDepartment,
                Description = department.DescriptionDepartment,
                Email = department.Email,
                PhoneNumber = department.PhoneNumber
            };
        }
    }
}
