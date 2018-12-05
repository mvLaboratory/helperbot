using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;
using RssReader.Models;

namespace RssReader
{
  class Program
  {
    static void Main(string[] args)
    {
      var url = "https://www.pravda.com.ua/rss/view_mainnews/";
      SyndicationFeed result = null;

      try
      {
        using (var reader = XmlReader.Create(url))
        {
          result = SyndicationFeed.Load(reader);
        }
      }
      catch (WebException ex)
      {
        //TODO:: log it
      }

      var feedItems = result?.Items.ToList().Select(item => new FeedItem(item));

      feedItems?.ToList().ForEach(Console.WriteLine);
      Console.ReadKey();
    }
  }
}
