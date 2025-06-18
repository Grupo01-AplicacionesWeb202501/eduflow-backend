namespace AcademicStaff.Domain.Model.Queries
{
    public class GetTeacherByIdQuery
    {
        public Guid TeacherId { get; }

        public GetTeacherByIdQuery(Guid teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
