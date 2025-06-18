namespace AcademicStaffContext.AcademicStaff.Application.DTO
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }  // Para update, en create puede ser ignorado
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }

}
