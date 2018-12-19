using Microsoft.EntityFrameworkCore;
using Models.Bot;

namespace DAL.Data
{
  public class BotSqlStorage : DbContext
  {
    public BotSqlStorage(DbContextOptions<BotSqlStorage> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
  }
}
