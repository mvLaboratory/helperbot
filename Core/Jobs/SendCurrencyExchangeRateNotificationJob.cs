using System;
using System.Linq;
using DAL;
using HelperBot;
using Models.Enums;

namespace Core.Jobs
{
  public class SendCurrencyExchangeRateNotificationJob : IJob
  {
    public SendCurrencyExchangeRateNotificationJob(HelperBotContext helperDbContext)
    {
      _dbContext = helperDbContext;
    }

    public void Execute()
    {
      var currency = Currency.Usd;
      var lastExchangeRate = _dbContext.CurrencyExchangeRate.OrderByDescending(rate => rate.Date).FirstOrDefault(rate => rate.Currency == currency);
      if (lastExchangeRate == null) return;
      Chat.Instance.SendMessage(lastExchangeRate.ToString());
    }

    private readonly HelperBotContext _dbContext;
  }
}
