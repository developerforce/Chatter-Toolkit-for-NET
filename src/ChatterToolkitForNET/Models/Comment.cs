namespace Salesforce.Chatter.Models
{
    public class Comment
    {
        public object attachment { get; set; }
        public FeedItemBody body { get; set; }
        public ClientInfo clientInfo { get; set; }
        public string createdDate { get; set; }
        public Reference feedItem { get; set; }
         public string id { get; set; }
        public bool isDeleteRestricted { get; set; }
        public Likes likes { get; set; }
        public LikesMessage likesMessage { get; set; }
        public MyLike myLike { get; set; }
        public Reference parent { get; set; }
        public string relativeCreatedDate { get; set; }
        public string type { get; set; }

        public string url { get; set; }
        public User user { get; set; }
    }
}