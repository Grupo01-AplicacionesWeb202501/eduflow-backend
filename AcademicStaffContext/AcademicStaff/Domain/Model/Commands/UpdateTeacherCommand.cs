namespace AcademicStaff.Domain.Model.Commands
{
    public class UpdateTeacherCommand
    {
        public Guid Id { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public string? Email { get; }
        public string? PhoneNumber { get; }
        public string? Speciality { get; }
        public string? AcademicDegree { get; }
        public int? YearsOfExperience { get; }

        public UpdateTeacherCommand(Guid id, string? firstName, string? lastName, string? email, string? phoneNumber, string? speciality, string? academicDegree, int? yearsOfExperience)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Speciality = speciality;
            AcademicDegree = academicDegree;
            YearsOfExperience = yearsOfExperience;
        }
    }

}
