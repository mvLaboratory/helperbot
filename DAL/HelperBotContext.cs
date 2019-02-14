using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL
{
  public class HelperBotContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=HelperBotDb;Integrated Security=True;");
                                  
    }

    public DbSet<CurrencyExchangeRate> CurrencyExchangeRate { get; set; }
  }
}
