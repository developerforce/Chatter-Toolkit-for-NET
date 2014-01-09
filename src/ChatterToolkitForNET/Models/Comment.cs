namespace Salesforce.Chatter.Models
{
    public class Comment
    {
        public Parent parent { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public ClientInfo clientInfo { get; set; }
        public Likes likes { get; set; }
        public string relativeCreatedDate { get; set; }
        public object likesMessage { get; set; }
        public bool isDeleteRestricted { get; set; }
        public object moderationFlags { get; set; }
        public object myLike { get; set; }
        public object attachment { get; set; }
        public string createdDate { get; set; }
        public string url { get; set; }
        public User user { get; set; }
        public FeedItemBody body { get; set; }
        public FeedItem feedItem { get; set; }
    }
}