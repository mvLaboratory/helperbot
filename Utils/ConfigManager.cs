using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HelperBot.Models;
using Microsoft.Extensions.Configuration;

namespace HelperBot.Utils
{
  public class ConfigManager
  {
    public static ConfigManager Instance => new ConfigManager();

    private ConfigManager()
    {
      var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
      var configuration = configurationBuilder.Build();
      var generalSettingsConfig = new AppConfig();
      configuration.GetSection("GeneralSettings").Bind(generalSettingsConfig);

    }

    ConfigManager insrtance;
  }
}