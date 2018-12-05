using System;
using System.Collections.Generic;
using System.Text;

namespace HelperBot.Data
{
  public interface IStorage
  {
    T ReadAll<T>();

    void Write<T>(T objectForSave);
  }
}
