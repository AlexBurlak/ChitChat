using ChitChat.DAL;
using ChitChat.DAL.Repositories;

namespace ChitChat.API.Configurations;

public static class DependeciesConfiguration
{
    public static void AddDependencies(this IServiceCollection collection)
    {
        collection.AddScoped<IChatRepository, ChatRepository>();
        collection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}