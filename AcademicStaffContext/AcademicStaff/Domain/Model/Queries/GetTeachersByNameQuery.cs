namespace AcademicStaffContext.AcademicStaff.Domain.Model.Queries
{
    public class GetTeachersByNameQuery
    {
        public string Name { get; }
        public GetTeachersByNameQuery(string name)
        {
            Name = name;
        }
    }
}
