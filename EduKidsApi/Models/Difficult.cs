namespace EduKidsApi.Models
{
    public class Difficult
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}
