using System;
using HelperBot;
using Telegram.Bot.Args;

namespace ConsoleChat
{
  class ConsoleChat
  {
    static void Main(string[] args)
    {
      var chat = Chat.Instance;
      chat.SubscribeToMessage(ChatMessageReceiver);

      Console.WriteLine("Bot is ready!");

      while (true)
      {
        var input = Console.ReadLine();
        if (input?.Equals("Exit", StringComparison.OrdinalIgnoreCase) ?? false)
        {
          break;
        }

        chat.SendMessage(input);
      }

    }

    public static void ChatMessageReceiver(object sender, MessageEventArgs args)
    {
      Console.WriteLine($"{args.Message.From}: {args.Message.Text}");
    }
  }
}
