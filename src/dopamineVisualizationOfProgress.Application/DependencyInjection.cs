using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IAccauntSevice, AccountService>();
        services.AddScoped<IDayService, DayService>();

        return services;
    }
}