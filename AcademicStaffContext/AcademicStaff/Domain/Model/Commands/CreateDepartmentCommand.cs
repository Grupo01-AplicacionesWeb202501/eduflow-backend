namespace AcademicStaffContext.AcademicStaff.Domain.Model.Commands
{
    public class CreateDepartmentCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public CreateDepartmentCommand(string name, string description, string email, string phoneNumber)
        {
            Name = name;
            Description = description;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

}
