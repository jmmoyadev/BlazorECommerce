using BlazorECommerceWeb_Domain;
using BlazorECommerceWeb_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BlazorECommerceWeb_Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.Scan(scan => scan
                .FromAssemblies(typeof(ApplicationDbContext).Assembly)
                .AddClasses(
                    filter => filter.Where(x => x.Name.EndsWith("Repository")),
                    publicOnly: true)
                .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                .AsMatchingInterface()
                .WithScopedLifetime());

        return services;
    }
}
