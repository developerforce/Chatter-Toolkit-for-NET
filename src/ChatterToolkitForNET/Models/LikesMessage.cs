using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class LikesMessage
    {
        public string text { get; set; }
        public List<MessageSegment> messageSegments { get; set; }
    }
}