using System.IO;
using HelperBot.Models;
using Microsoft.Extensions.Configuration;

namespace HelperBot.Utils
{
  public class ConfigManager
  {
    public static ConfigManager Settings => _instance ?? (_instance = new ConfigManager());
    public AppConfig AppConfig { get; } = new AppConfig();

    private ConfigManager()
    {
      var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
      var configuration = configurationBuilder.Build();

      configuration.GetSection("GeneralSettings").Bind(AppConfig);
    }

    private static ConfigManager _instance;
  }
}