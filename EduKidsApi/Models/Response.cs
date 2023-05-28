namespace EduKidsApi.Models
{
    public class Response
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public List<ResponseDetail> ResponseDetails { get; set; } = new List<ResponseDetail>();
    }
}
