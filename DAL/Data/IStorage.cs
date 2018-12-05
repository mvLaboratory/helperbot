using System.Collections.Generic;

namespace DAL.Data
{
  public interface IStorage
  {
    HashSet<T> ReadAll<T>() where T : new();

    void Write<T>(T objectForSave) where T : new();
  }
}
