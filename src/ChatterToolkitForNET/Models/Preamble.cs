using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Preamble
    {
        public List<MessageSegment> messageSegments { get; set; }
        public string text { get; set; }
    }
}