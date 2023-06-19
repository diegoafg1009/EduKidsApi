namespace EduKidsApi.Dtos
{
    public class AlternativeDto
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
