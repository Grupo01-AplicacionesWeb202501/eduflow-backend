namespace EduflowAdminBackend.Models
{
    public class Section
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public Course Course { get; set; }
    }
}