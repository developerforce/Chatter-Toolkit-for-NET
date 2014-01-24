namespace Salesforce.Chatter.Models
{
    public class Like
    {
        public string id { get; set; }
        public string url { get; set; }

        public User user { get; set; }

        public Reference likedItem { get; set; }
    }
}