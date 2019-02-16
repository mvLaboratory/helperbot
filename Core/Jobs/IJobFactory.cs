using System;
using System.Collections.Generic;

namespace Core.Jobs
{
  public interface IJobFactory
  {
    List<Tuple<IJob, string>> GetDefailtJobs();
  }
}
