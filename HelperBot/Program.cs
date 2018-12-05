using System;
using System.Collections.Generic;
using System.IO;
using HelperBot.Data;
using HelperBot.Models;
using HelperBot.Utils;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace HelperBot
{
  class Program
  {
    private static readonly TelegramBotClient Bot = new TelegramBotClient(ConfigManager.Settings.AppConfig.BotId);
    private static FileStorage _storage;

    static void Main(string[] args)
    {
      _storage = new FileStorage();
      Bot.OnMessage += MsgEvnt;
      Bot.OnMessageEdited += MsgEvnt;

      Bot.StartReceiving();

      while (true)
      {
        var input = Console.ReadLine();
        if (input?.Equals("Exit", StringComparison.OrdinalIgnoreCase) ?? false)
        {
          break;
        }
        Bot.SendTextMessageAsync(_storage.ReadAll<Client>().ChatId, input);
      }
   
      Bot.StopReceiving();
    }

    public static void MsgEvnt(object sender, MessageEventArgs args)
    {
      Console.WriteLine(args.Message.Text);
      _storage.Write(new Client { ChatId = args.Message.Chat.Id });
    }
  }
}
