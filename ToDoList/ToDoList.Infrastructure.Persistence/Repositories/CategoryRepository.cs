using ToDoList.Application.Interfaces.Repositories;
using ToDoList.Domain.CategoryDomain.Entities;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ToDoListDbContext context) : base(context){}

    }
}
