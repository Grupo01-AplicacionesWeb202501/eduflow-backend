namespace AcademicStaffContext.AcademicStaff.Domain.Model.Queries
{
    public class GetDepartmentsByNameQuery
    {
        public string Name { get; }
        public GetDepartmentsByNameQuery(string name)
        {
            Name = name;
        }
    }
}
