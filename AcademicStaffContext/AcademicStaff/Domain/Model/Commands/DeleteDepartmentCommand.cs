namespace AcademicStaffContext.AcademicStaff.Domain.Model.Commands
{
    public class DeleteDepartmentCommand
    {
        public Guid Id { get; }
        public DeleteDepartmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
