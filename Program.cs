using System;
using System.Collections.Generic;
using System.IO;
using HelperBot.Models;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace HelperBot
{
  class Program
  {
    private static readonly TelegramBotClient bot = new TelegramBotClient("798717728:AAE14QSFQFEcpkeYm4VGR1ibbcAYEN20nkg");
    private static long LastChatId;

    static void Main(string[] args)
    {


      //Console.WriteLine(generalSettingsConfig.FileStoragePath);


      var clients = new List<long>();
      var clientStorage = new FileInfo("ClientInfo");
      if (clientStorage.Exists)
      {
        //clientStorage.OpenRead()
      }

      Console.WriteLine("Hello World!");
      bot.OnMessage += MsgEvnt;
      bot.OnMessageEdited += MsgEvnt;

      bot.StartReceiving();

      var input = Console.ReadLine();
      if (LastChatId == 0)
      {
        Console.WriteLine("No chat is available.");
        Console.ReadKey();
        return;

      }
      bot.SendTextMessageAsync(LastChatId, input);

      Console.ReadKey();
      bot.StartReceiving();
    }

    public static void MsgEvnt(object sender, MessageEventArgs args)
    {
      LastChatId = args.Message.Chat.Id;
    }
  }
}
