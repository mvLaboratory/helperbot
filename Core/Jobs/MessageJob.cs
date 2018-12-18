﻿using System;
using HelperBot;

namespace Core.Jobs
{
  public class MessageJob
  {
    public static MessageJob Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (PadLock)
          {
            if (_instance == null)
            {
              _instance = new MessageJob();
            }
          }
        }
        return _instance;
      }
    }

    private MessageJob()
    {
      
    }

    public void SendAllRecipients()
    {
      TelegramChat.Instance.SendMessage($"UTC time is: {DateTime.UtcNow}");
    }

    private static MessageJob _instance;
    private static readonly Object PadLock = new Object();
  }
}
