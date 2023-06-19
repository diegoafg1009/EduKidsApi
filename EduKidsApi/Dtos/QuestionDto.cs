using EduKidsApi.Models;

namespace EduKidsApi.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public List<AlternativeDto> Alternatives { get; set; } = new List<AlternativeDto>();
    }
}
