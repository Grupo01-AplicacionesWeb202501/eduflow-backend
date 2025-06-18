namespace AcademicStaffContext.AcademicStaff.Application.DTO
{
    public class TeacherDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Speciality { get; set; }
        public string AcademicDegree { get; set; }
        public int YearsOfExperience { get; set; }
    }

}
