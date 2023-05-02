using ToDoList.Application.Interfaces;

namespace ToDoList.Infrastructure.Persistence.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoListDbContext _dbContext;

        public UnitOfWork(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CommitAsync() => await _dbContext.SaveChangesAsync() > 0 ? true : false;
        public void Dispose() => _dbContext.DisposeAsync();
    }
}
