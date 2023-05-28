namespace EduKidsApi.Models
{
    public class Alternative
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }
        public List<ResponseDetail> ResponseDetails { get; set; } = new List<ResponseDetail>();
    }
}
