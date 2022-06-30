using ChitChat.API.Helpers;
using ChitChat.DAL;
using ChitChat.DAL.Repositories;

namespace ChitChat.API.Configurations;

public static class DependeciesConfiguration
{
    public static void AddDependencies(this IServiceCollection collection)
    {
        collection.AddTransient<IChatRepository, ChatRepository>();
        collection.AddTransient<IUnitOfWork, UnitOfWork>();
        collection.AddTransient<IJWTHelper, JWTHelper>();
    }
}