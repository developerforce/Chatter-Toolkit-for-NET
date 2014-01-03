using System.Collections.Generic;

namespace ChatterToolkitForNET.Models
{
    public class Preamble
    {
        public string text { get; set; }
        public List<MessageSegment> messageSegments { get; set; }
    }
}