using System;
using System.IO;
using Newtonsoft.Json;
using Utils;

namespace HelperBot.Data
{
  public class DelFileStorage 
  {
    public T[] ReadAll<T>()
    {
      var rawData = File.ReadAllText(ConfigManager.Settings.AppConfig.FileStoragePath);
      return JsonConvert.DeserializeObject<T[]>(rawData);
    }

    public void Write<T>(T objectForSave)
    {
      var serialisedObj = JsonConvert.SerializeObject(objectForSave) ?? throw new ArgumentNullException(nameof(objectForSave));
      using (var file = new StreamWriter(ConfigManager.Settings.AppConfig.FileStoragePath, false))
      {
        file.WriteLine(serialisedObj);
      }
    }
  }
}
