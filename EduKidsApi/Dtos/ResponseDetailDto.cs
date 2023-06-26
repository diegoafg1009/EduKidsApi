namespace EduKidsApi.Dtos
{
    public class ResponseDetailDto
    {
        public string? Question { get; set; }
        public string? Alternative { get; set; }
        public bool IsCorrect { get; set; }
    }
}
