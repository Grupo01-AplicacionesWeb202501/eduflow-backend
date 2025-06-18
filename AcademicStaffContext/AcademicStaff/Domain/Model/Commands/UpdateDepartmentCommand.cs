namespace AcademicStaffContext.AcademicStaff.Domain.Model.Commands
{
    public class UpdateDepartmentCommand
    {
        public Guid Id { get; }
        public string? Name { get; }
        public string? Description { get; }
        public string? Email { get; }
        public string? PhoneNumber { get; }
        public UpdateDepartmentCommand(Guid id, string? name, string? description, string? email, 
            string? phoneNumber)
        {
            Id = id;
            Name = name;
            Description = description;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
