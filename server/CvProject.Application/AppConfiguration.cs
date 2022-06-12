using Microsoft.Extensions.Configuration;

namespace CvProject.Application;

public static class AppConfiguration
{
    private static IConfigurationRoot appConfiguration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile("appsettings.Development.json", true, true)
        .Build();

    public static string DefaultDbConnection { get => appConfiguration["ConnectionStrings:DefaultConnection"]; }
}
