using EduKidsApi.Core;
using EduKidsApi.Core.Repositories;

namespace EduKidsApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IMatterRepository Matters { get; }
        public ITopicRepository Topics { get; }
        public IResponseRepository Responses { get; }
        public IQuestionRepository Questions { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Matters = new MatterRepository(_context);
            Topics = new TopicRepository(_context);
            Responses = new ResponseRepository(_context);
            Questions = new QuestionRepository(_context);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
