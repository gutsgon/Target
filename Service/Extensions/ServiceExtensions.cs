
namespace Target.Service.Extensions
{
    public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Adiciona os serviços
        services.AddScoped<IDiaValorService, DiaValorService>();
        services.AddScoped<ILoginService, LoginService>();
        return services;
    }
}
}