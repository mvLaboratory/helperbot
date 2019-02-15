using System;
using Models.Enums;

namespace Models.Entities
{
  public class CurrencyExchangeRate
  {
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }
    public decimal BuyRate { get; set; }
    public decimal SellRate { get; set; }

    public override string ToString()
    {
      return $"{Date}: {Currency} - {BuyRate}/{SellRate}";
    }
  }
}
