using EduKidsApi.Dtos;
using EduKidsApi.Models;

namespace EduKidsApi.Core
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<IEnumerable<QuestionDto>> GetByTopicIdWithAlternatives(Guid topicId);
        Task<IEnumerable<QuestionDto>> GetQuestionsPerTopic();
    }
}
