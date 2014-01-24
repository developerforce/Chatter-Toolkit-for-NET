using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class FeedItemBody
    {
       public List<MessageSegment> messageSegments { get; set; }
       public string text { get; set; }
    }
}