using ETicketStore.Domain.Repository;

namespace ETicketStore;

public static class StartupExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<IETicketRepository>();
        services.AddSingleton<IEventRepository>();
        services.AddSingleton<ICustomerRepository>();
        return services;
    }
}