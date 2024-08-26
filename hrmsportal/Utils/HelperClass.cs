using Microsoft.Extensions.Configuration;
namespace hrmsportal.Utils
{
    public static class HelperClass
    {
        public static string GetAppSettings(string key = "BaseUrl")
        {
            var appSettings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetSection("AppSettings")[key];
            return appSettings ?? string.Empty;
        }
        public static string GetAppSettings(string section = "AppSettings", string key = "BaseUrl")
        {
            var appSettings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetSection(section)[key];
            return appSettings ?? string.Empty;
        }

        public static string GetAPIUrl(string endpointKey)
        {
            var BaseUrl = GetAppSettings("BaseUrl");
            var endpoint = GetAppSettings("API_Endpoints", endpointKey);
            return BaseUrl != null && endpoint != null ? BaseUrl + endpoint : string.Empty;
        }
    }
}