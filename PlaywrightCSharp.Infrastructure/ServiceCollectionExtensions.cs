using Microsoft.Extensions.DependencyInjection;
using PlaywrightCSharp.Infrastructure.Helpers;
using PlaywrightCSharp.Infrastructure.Pages;
using PlaywrightCSharp.Infrastructure.ResourceProviders;

namespace PlaywrightCSharp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string configPath)
        {
            return services
                .AddSingleton(_ => new PlaywrightConfigProvider(configPath).PlaywrightConfig)
                .AddSingleton<PlaywrightProvider>()
                .AddSingleton<BrowserProvider>()
                .AddScoped<PageProvider>()
                .AddScoped(sp => sp.GetRequiredService<PageProvider>().Resource.ConfigureAwait(false).GetAwaiter().GetResult())
                .AddScoped<MainPage>()
                // here add new pages if you need
                ;
        }
    }
}
