namespace StudentPortalApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}