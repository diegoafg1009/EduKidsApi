namespace EduKidsApi.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public Guid TopicId { get; set; }
        public List<Alternative> Alternatives { get; set; } = new List<Alternative>();
        public List<ResponseDetail> ResponseDetails { get; set; } = new List<ResponseDetail>();
    }
}
