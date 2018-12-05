using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Models
{
  public class FeedItem
  {
    public String Id { get; set; }
    public String Category { get; set; }
    public String Link { get; set; }
    public DateTime PublishDate { get; set; }
    public String Title { get; set; }
    public String Text { get; set; }

    public FeedItem()
    {
        
    }

    public FeedItem(SyndicationItem item)
    {
      Id = item.Id;
      Category = item.Categories.FirstOrDefault()?.Name ?? "";
      Link = item.Links.FirstOrDefault()?.Uri.AbsoluteUri ?? "";
      Title = item.Title.Text;
      Text = item.Title.Text;
      PublishDate = item.PublishDate.UtcDateTime;
    }

    public override string ToString()
    {
      return $"{{Id:{Id}, Category: {Category}, Link: {Link}, Title:{Title}, PublishDate: {PublishDate}}}";
    }
  }
}
