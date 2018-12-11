using Microsoft.EntityFrameworkCore;

namespace DAL
{
  public class ChatStorage : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HelperBotDb;Trusted_Connection=True;");
    }
  }
}
