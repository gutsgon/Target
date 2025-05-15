
namespace Target.Service.Extensions
{
    public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDiaValorService, DiaValorService>();
        // Aqui você adiciona todos os outros serviços
        // services.AddScoped<IOutroService, OutroService>();

        return services;
    }
}
}