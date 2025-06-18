using AcademicStaff.Domain.Model.Queries;
using AcademicStaffContext.AcademicStaff.Application.DTO;
using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;
using AcademicStaffContext.AcademicStaff.Domain.Model.Queries;
using AcademicStaffContext.AcademicStaff.Domain.Repositories;


namespace AcademicStaff.Application.Internal.QueryServices
{
    public class TeacherQueryService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherQueryService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherDto?> GetByIdAsync(GetTeacherByIdQuery query)
        {
            var teacher = await _teacherRepository.GetByIdAsync(query.TeacherId);
            return teacher == null ? null : MapToDto(teacher);
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync(GetAllTeachersQuery query)
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers.Select(MapToDto).ToList();
        }

        public async Task<IEnumerable<TeacherDto>> GetByNameAsync(GetTeachersByNameQuery query)
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers
                .Where(t => t.FirstName.Contains(query.Name, StringComparison.OrdinalIgnoreCase))
                .Select(MapToDto)
                .ToList();
        }

        private TeacherDto MapToDto(Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                Speciality = teacher.Speciality,
                AcademicDegree = teacher.AcademicDegree.Value,
                YearsOfExperience = teacher.YearsOfExperience
            };
        }
    }
}
