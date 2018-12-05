using System;
using System.IO;
using HelperBot.Utils;
using Newtonsoft.Json;

namespace HelperBot.Data
{
  public class FileStorage : IStorage
  {
    public T ReadAll<T>()
    {
      var rawData = File.ReadAllText(DelConfigManager.Settings.AppConfig.FileStoragePath);
      return JsonConvert.DeserializeObject<T>(rawData);
    }

    public void Write<T>(T objectForSave)
    {
      var serialisedObj = JsonConvert.SerializeObject(objectForSave) ?? throw new ArgumentNullException(nameof(objectForSave));
      using (var file = new StreamWriter(DelConfigManager.Settings.AppConfig.FileStoragePath, false))
      {
        file.WriteLine(serialisedObj);
      }
    }
  }
}
