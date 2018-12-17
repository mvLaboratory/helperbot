using HelperBot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
  public class MessageSender
  {
    public static MessageSender Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (_padLock)
          {
            if (_instance == null)
            {
              _instance = new MessageSender();
            }
          }
        }
        return _instance;
      }
    }

    private MessageSender()
    {
      
    }

    public void SendAllRecipients()
    {
      Chat.Instance.SendMessage("test");
    }

    private static MessageSender _instance;
    private static readonly Object _padLock = new Object();
  }
}
