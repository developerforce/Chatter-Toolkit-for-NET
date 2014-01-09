namespace Salesforce.Chatter.Models
{
    public class MessageSegment
    {
        public string type { get; set; }
        public string text { get; set; }
        public string id { get; set; }
        public Reference reference { get; set; }
        public Motif motif { get; set; }
    }
}