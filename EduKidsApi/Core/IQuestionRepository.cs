using EduKidsApi.Dtos;
using EduKidsApi.Models;

namespace EduKidsApi.Core
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<IEnumerable<QuestionDto>> GetWithAlternatives();
        Task<IEnumerable<Question>> GetQuestionsPerTopic();
    }
}
