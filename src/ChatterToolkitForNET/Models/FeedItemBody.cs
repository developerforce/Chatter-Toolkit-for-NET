using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class FeedItemBody
    {
        public string text { get; set; }
        public List<MessageSegment> messageSegments { get; set; }
    }
}