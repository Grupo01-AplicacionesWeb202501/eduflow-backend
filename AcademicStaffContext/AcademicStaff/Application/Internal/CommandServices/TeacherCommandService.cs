using AcademicStaff.Domain.Model.Commands;
using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;
using AcademicStaffContext.AcademicStaff.Domain.Repositories;
using AcademicStaffContext.Shared.Infraestructure.Persistence.EFC.Configuration;


namespace AcademicStaff.Application.Internal.CommandServices
{
    public class TeacherCommandService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly AppDbContext _context;

        public TeacherCommandService(ITeacherRepository teacherRepository, AppDbContext context)
        {
            _teacherRepository = teacherRepository;
            _context = context;
        }

        public async Task<Guid> CreateAsync(CreateTeacherCommand command)
        {
            var teacher = new Teacher(
                command.Name,
                command.LastName,
                command.Email,
                command.PhoneNumber,
                command.Speciality,
                command.AcademicDegree,
                command.YearsOfExperience
            );

            await _teacherRepository.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return teacher.Id;
        }

        public async Task<bool> UpdateAsync(UpdateTeacherCommand command)
        {
            var teacher = await _teacherRepository.GetByIdAsync(command.Id);
            if (teacher == null) return false;

            // Usa los valores nuevos si están definidos, si no, conserva los actuales
            var updatedFirstName = command.FirstName ?? teacher.FirstName;
            var updatedLastName = command.LastName ?? teacher.LastName;
            var updatedEmail = command.Email ?? teacher.Email;
            var updatedPhone = command.PhoneNumber ?? teacher.PhoneNumber;
            var updatedSpeciality = command.Speciality ?? teacher.Speciality;
            var updatedAcademicDegree = command.AcademicDegree ?? teacher.AcademicDegree.Value;
            var updatedYearsOfExperience = command.YearsOfExperience ?? teacher.YearsOfExperience;

            teacher.Update(updatedFirstName, updatedLastName, updatedEmail, updatedPhone, updatedSpeciality,
                updatedAcademicDegree, updatedYearsOfExperience);

            _teacherRepository.Update(teacher);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(DeleteTeacherCommand command)
        {
            var teacher = await _teacherRepository.GetByIdAsync(command.Id);
            if (teacher == null) return false;

            _teacherRepository.Delete(teacher);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
