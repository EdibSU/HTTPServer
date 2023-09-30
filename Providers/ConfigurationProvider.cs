using Microsoft.Extensions.Configuration;

namespace HTTPServer.Providers
{
    public sealed class ConfigurationProvider
    {
        private static readonly IConfigurationRoot _configuration;

        static ConfigurationProvider()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile(PathProvider.Configuration).Build();
        }

        public static string Domain => _configuration["domain"] ?? string.Empty;

        public static string Port => _configuration["port"] ?? string.Empty;
    }
}