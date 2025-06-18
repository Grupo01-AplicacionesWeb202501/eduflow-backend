using AcademicStaffContext.AcademicStaff.Domain.Model.Commands;
using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;
using AcademicStaffContext.AcademicStaff.Domain.Repositories;
using AcademicStaffContext.Shared.Infraestructure.Persistence.EFC.Configuration;

namespace AcademicStaffContext.AcademicStaff.Application.Internal.CommandServices
{
    public class DepartmentCommandService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly AppDbContext _context;

        public DepartmentCommandService(IDepartmentRepository departmentRepository, AppDbContext context)
        {
            _departmentRepository = departmentRepository;
            _context = context;
        }

        public async Task<Guid> CreateAsync(CreateDepartmentCommand command)
        {
            // Utiliza un constructor o un método de fábrica para inicializar la propiedad Id
            var department = new Department(
                command.Name,
                command.Description,
                command.Email,
                command.PhoneNumber
            );

            await _departmentRepository.AddAsync(department);
            await _context.SaveChangesAsync();

            return department.Id;
        }

        public async Task<bool> UpdateAsync(UpdateDepartmentCommand command)
        {
            var department = await _departmentRepository.GetByIdAsync(command.Id);
            if (department == null) return false;

            department.Update(command.Name, command.Description, command.Email, command.PhoneNumber);
            await _context.SaveChangesAsync();

            return true;
        }



        public async Task<bool> DeleteAsync(DeleteDepartmentCommand command)
        {
            var department = await _departmentRepository.GetByIdAsync(command.Id);
            if (department == null) return false;

            _departmentRepository.Delete(department);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

