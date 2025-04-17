using ToDolist.Bll.Services;
using ToDoList.StorageBroker.Services;

namespace ToDoList.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IToDoItemRepositoryAdoNet, ToDoItemRepositoryAdoNet>();
        services.AddScoped<IToDoItemServiceAdoNet, ToDoItemServiceAdoNet>();
        //services.AddScoped<MainContext>();
    }
}
