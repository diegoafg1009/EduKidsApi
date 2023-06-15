using EduKidsApi.Models;

namespace EduKidsApi.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public List<Alternative> Alternatives { get; set; } = new List<Alternative>();
    }
}
