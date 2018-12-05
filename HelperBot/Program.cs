using System;
using System.Linq;
using DAL.Data;
using Models.Bot;
using Telegram.Bot;
using Telegram.Bot.Args;
using Utils;

namespace HelperBot
{
  class Program
  {
    private static readonly TelegramBotClient Bot = new TelegramBotClient(ConfigManager.Settings.AppConfig.BotId);
    private static FileStorage _storage;

    static void Main(string[] args)
    {
      Console.WriteLine("Start:");
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

        _storage.ReadAll<Client>().ToList().ForEach(client =>
            Bot.SendTextMessageAsync(client.ChatId, input)
          );
      }
   
      Bot.StopReceiving();
    }

    public static void MsgEvnt(object sender, MessageEventArgs args)
    {
      Console.WriteLine($"{args.Message.From.ToString()}: {args.Message.Text}");
      _storage.Write(new Client { ChatId = args.Message.Chat.Id });
    }
  }
}
