using AcademicStaffContext.AcademicStaff.Domain.Model.Entities;

namespace AcademicStaff.Domain.Model.Aggregates
{
    public class TeacherAggregate
    {
        public Teacher Teacher { get; private set; }

        public TeacherAggregate(Teacher teacher)
        {
            Teacher = teacher;
        }

        // Métodos que garanticen invariantes del agregado
        public void UpdateEmail(string newEmail)
        {
            // Validar formato, reglas...
            Teacher.Update(Teacher.FirstName, Teacher.LastName, newEmail, Teacher.PhoneNumber, Teacher.Speciality,
                Teacher.AcademicDegree.Value, Teacher.YearsOfExperience);
        }
    }
}
