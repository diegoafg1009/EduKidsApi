namespace EduKidsApi.Core
{
    public interface IUnitOfWork
    {
        IMatterRepository Matters { get; }
        ITopicRepository Topics { get; }
        IResponseRepository Responses { get; }
        //IQuestionRepository Questions { get; }
        //IAnswerRepository Answers { get; }
        Task CommitAsync();

    }
}
