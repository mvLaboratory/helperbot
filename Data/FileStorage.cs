using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelperBot.Data
{
  public class FileStorage : IStorage
  {
    public String ReadAll()
    {
      return "";
    }

    public void Write()
    {
      using (var file = new StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
      {
        file.WriteLine("Fourth line");
      }
    }
  }
}
