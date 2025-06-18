namespace AcademicStaff.Domain.Model.Commands
{
    public class DeleteTeacherCommand
    {
        public Guid Id { get; }

        public DeleteTeacherCommand(Guid id)
        {
            Id = id;
        }
    }
}
