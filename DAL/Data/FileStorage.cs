using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace DAL.Data
{
  public class FileStorage :IStorage
  {
    public HashSet<T> ReadAll<T>() where T :new()
    {
      var storageFile = GetTypeStoreFile(typeof(T));
      if (!File.Exists(storageFile))
      {
        return new HashSet<T>();
      }
      var rawData = File.ReadAllText(storageFile);

      var result = JsonConvert.DeserializeObject<HashSet<T>>(rawData);
      return result;
    }

    public void Write<T>(T objectForSave) where T : new()
    {
      var storageFile = GetTypeStoreFile(typeof(T));
      var existingData = ReadAll<T>();
      existingData.Add(objectForSave);

      var serialisedObj = JsonConvert.SerializeObject(existingData) ?? throw new ArgumentNullException(nameof(objectForSave));

      var fileInfo = new FileInfo(storageFile);
      if (!fileInfo.Directory.Exists)
      {
        Directory.CreateDirectory(fileInfo.DirectoryName);
      }
      using (var file = new StreamWriter(GetTypeStoreFile(typeof(T)), false))
      {
        file.WriteLine(serialisedObj);
      }
    }

    private String GetTypeStoreFile(Type type)
    {
      return $"{ConfigManager.Settings.AppConfig.FileStoragePath}/{type.FullName}.json";
    }
  }
}
