namespace AcademicStaffContext.AcademicStaff.Domain.Model.Queries
{
    public class GetDepartmentByIdQuery
    {
        public Guid DepartmentId { get; }
        public GetDepartmentByIdQuery(Guid departmentId)
            {
                DepartmentId = departmentId;
        }
    }
}
