using DAL;
using System;

namespace Models.Bot
{
  public class Client : Entity
  {
    public Int64 ChatId { get; set; }

    protected bool Equals(Client other)
    {
      return ChatId == other.ChatId;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Client) obj);
    }

    public override int GetHashCode()
    {
      return ChatId.GetHashCode();
    }

    public static bool operator == (Client left, Client right)
    {
      return Equals(left, right);
    }

    public static bool operator != (Client left, Client right)
    {
      return !Equals(left, right);
    }
  }
}
