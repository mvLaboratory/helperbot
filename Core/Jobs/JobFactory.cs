using Hangfire;

namespace Core.Jobs
{
  public class JobFactory : IJobFactory
  {
    public JobFactory(ITelegramChat telegramChat)
    {
      _telegramChat = telegramChat;
    }

    public void SetUpDefaultJobs()
    {
      RecurringJob.AddOrUpdate(() => MessageCheck(), Cron.MinuteInterval(10));
    }

    public void MessageCheck()
    {
      MessageJob.Instance.SendAllRecipients();
    }

    private readonly ITelegramChat _telegramChat;
  }
}
