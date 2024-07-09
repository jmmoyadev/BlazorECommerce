using BlazorECommerceWeb_Server.Data;
using BlazorECommerceWeb_Server.Extensions;
using BlazorECommerceWeb_Server.Services;

namespace BlazorECommerceWeb_Server;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApplication(this IServiceCollection services)
    {
        services.AddSingleton<WeatherForecastService>();
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<IFileUpload, FileUpload>();

        return services;
    }
}
