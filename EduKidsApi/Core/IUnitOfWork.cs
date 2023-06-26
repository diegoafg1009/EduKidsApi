namespace EduKidsApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMatterRepository Matters { get; }
        ITopicRepository Topics { get; }
        IResponseRepository Responses { get; }
        IQuestionRepository Questions { get; }
        IResponseDetailRepository ResponseDetails { get; }
        Task CommitAsync();

    }
}
