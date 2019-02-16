using DAL;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core.Jobs
{
  public class JobFactory : IJobFactory
  {
    public JobFactory(DbContextOptions<HelperBotContext> dbOptions)
    //public JobFactory(HelperBotContext helperDbContext)
    {
      _dbContext = new HelperBotContext(dbOptions);
      //_dbContext = helperDbContext;
    }

    public List<Tuple<IJob, string>> GetDefailtJobs()
    {
      var result = new List<Tuple<IJob, string>>
      {
        new Tuple<IJob, string>(new SendCurrencyExchangeRateNotificationJob(_dbContext), "*/10 * * * *")
      };

      return result;
    }

    private readonly HelperBotContext _dbContext;
  }
}
