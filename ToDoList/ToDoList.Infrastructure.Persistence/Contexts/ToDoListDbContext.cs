using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.CategoryDomain.Entities;
using ToDoList.Domain.ToDoTaskDomain.Entities;

namespace ToDoList.Infrastructure.Persistence.Contexts
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<ToDoTask> ToDoTask { get; set; }
    }
}
