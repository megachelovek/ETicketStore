using ETicketStore.Domain.Repository;

namespace ETicketStore;

public static class StartupExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<ETicketRepository>();
        services.AddSingleton<EventRepository>();
        services.AddSingleton<CustomerRepository>();
        return services;
    }
}