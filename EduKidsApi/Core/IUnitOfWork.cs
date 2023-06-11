namespace EduKidsApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMatterRepository Matters { get; }
        ITopicRepository Topics { get; }
        IResponseRepository Responses { get; }
        Task CommitAsync();

    }
}
