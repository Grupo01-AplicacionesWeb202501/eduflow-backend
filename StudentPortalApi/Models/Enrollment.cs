namespace StudentPortalApi.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string CourseName { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.Now;
    }
}