using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.CategoryDomain.Entities;

namespace ToDoList.Infrastructure.Persistence.Contexts.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x=>x.ToDoTasks)
                   .WithOne(x=>x.Category)
                   .HasForeignKey(sn => sn.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
