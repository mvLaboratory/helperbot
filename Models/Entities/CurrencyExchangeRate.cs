using System;
using System.Collections.Generic;
using System.Text;
using Models.Enums;

namespace Models.Entities
{
  public class CurrencyExchangeRate
  {
    public long Id { get; set; }
    public Currency Currency { get; set; }
    public decimal BuyRate { get; set; }
    public decimal SellRate { get; set; }
  }
}
