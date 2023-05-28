namespace EduKidsApi.Models
{
    public class ResponseDetail
    {
        public Guid Id { get; set; }
        public Guid? ResponseId { get; set; }
        public Response? Response { get; set; }
        public Guid? AlternativeId { get; set; }
        public Alternative? Alternative { get; set; }
        public Guid? QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
