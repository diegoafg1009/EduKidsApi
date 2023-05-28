namespace EduKidsApi.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid DifficultId { get; set; }
        public Difficult? Difficult { get; set; }
        public Guid MatterId { get; set; }
        public Matter? Matter { get; set; }
    }
}
