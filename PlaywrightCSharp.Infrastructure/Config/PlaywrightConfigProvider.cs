using Microsoft.Extensions.Configuration;

namespace PlaywrightCSharp.Infrastructure.Helpers
{
    public class PlaywrightConfigProvider
    {
        private readonly IConfiguration _config;

        public PlaywrightConfigProvider(string path)
        {
            _config = new ConfigurationBuilder()
            .AddJsonFile(path)
            .AddEnvironmentVariables()
            .Build();

            PlaywrightConfig = _config.Get<PlaywrightConfig>()!;
        }

        public PlaywrightConfig PlaywrightConfig { get; }

    }
}
