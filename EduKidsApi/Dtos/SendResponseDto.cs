using EduKidsApi.Models;

namespace EduKidsApi.Dtos
{
    public class SendResponseDto
    {
        public string Username { get; set; }
        public List<ResponseDetail> ResponseDetails { get; set; } = new List<ResponseDetail>();
    }
}
