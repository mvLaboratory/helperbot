using System;
using System.Linq;
using Core;
using DAL.Data;
using Models.Bot;
using Telegram.Bot;
using Telegram.Bot.Args;
using Utils;

namespace HelperBot
{
  public class TelegramChat : ITelegramChat, IDisposable
  {
    public TelegramChat()
    {
      _storage = new FileStorage();
      _bot = new TelegramBotClient(ConfigManager.Settings.AppConfig.BotId);

      _bot.OnMessage += DefaultHandler;
      _bot.OnMessageEdited += DefaultHandler;

      _bot.StartReceiving();
    }

    public void SendMessage(String input)
    {
      _storage.ReadAll<Client>().ToList().ForEach(client =>
        _bot.SendTextMessageAsync(client.ChatId, input)
      );
    }

    public void SubscribeToMessage(System.EventHandler<MessageEventArgs> handler)
    {
      _bot.OnMessage += handler;
      _bot.OnMessageEdited += handler;
    }

    public void DefaultHandler(object sender, MessageEventArgs args)
    {
      _storage.Write(new Client { ChatId = args.Message.Chat.Id });
    }

    public void Dispose()
    {
      _bot.StopReceiving();
    }

    ~TelegramChat()
    {
      Dispose();
    }

    private static TelegramChat _instance;
    private readonly TelegramBotClient _bot;
    private readonly FileStorage _storage;
  }
}
