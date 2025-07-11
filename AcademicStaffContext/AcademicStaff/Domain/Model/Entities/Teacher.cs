using AcademicStaffContext.AcademicStaff.Domain.Model.ValueObjects;
using System.Security.Cryptography.X509Certificates;

namespace AcademicStaffContext.AcademicStaff.Domain.Model.Entities;
public class Teacher
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Speciality { get; set; }
    public AcademicDegree AcademicDegree { get; set; }  // Aquí usas el VO
    public int YearsOfExperience { get; set; }

    // Constructor requerido por EF Core
    public Teacher() { }

    public Teacher(string firstName, string lastName, string email, string phoneNumber, string speciality, string academicDegree, int yearsOfExperience, Guid departmentId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Speciality = speciality;
        AcademicDegree = new AcademicDegree(academicDegree);  // Aquí creas el VO
        YearsOfExperience = yearsOfExperience;
    }

    public void Update(string firstName, string lastName, string email, string phoneNumber, string speciality, string academicDegree, int yearsOfExperience)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Speciality = speciality;
        AcademicDegree = new AcademicDegree(academicDegree);  // También aquí
        YearsOfExperience = yearsOfExperience;
    }
}
