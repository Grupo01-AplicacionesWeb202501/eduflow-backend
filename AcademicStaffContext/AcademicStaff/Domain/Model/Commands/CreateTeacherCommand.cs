namespace AcademicStaff.Domain.Model.Commands
{
    public class CreateTeacherCommand
    {
        public string Name { get; }
        public string LastName { get; } // Assuming LastName is also required, adjust as necessary
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Speciality { get; }
        public string AcademicDegree { get; }
        public int YearsOfExperience { get; }

        public CreateTeacherCommand(string name, string lastName, string email, string phoneNumber, string speciality, string academicDegree, int yearsOfExperience)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Speciality = speciality;
            AcademicDegree = academicDegree;
            YearsOfExperience = yearsOfExperience;
        }
    }
}
