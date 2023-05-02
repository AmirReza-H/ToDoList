using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Interfaces.Repositories;
using ToDoList.Infrastructure.Persistence.Contexts;
using ToDoList.Infrastructure.Persistence.Repositories;

namespace ToDoList.Infrastructure.Persistence
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<ICategoryRepository, CategoryRepository>()
                    ;

            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoListDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ToDoList")));

            return services;
        }
    }
}
