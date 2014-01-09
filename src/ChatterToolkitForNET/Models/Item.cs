namespace Salesforce.Chatter.Models
{
    public class Item
    {
        public Parent parent { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public Topics topics { get; set; }
        public string photoUrl { get; set; }
        public Actor actor { get; set; }
        public string modifiedDate { get; set; }
        public string url { get; set; }
        public string createdDate { get; set; }
        public ClientInfo clientInfo { get; set; }
        public FeedItemBody body { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Preamble preamble { get; set; }
        public bool canShare { get; set; }
        public string relativeCreatedDate { get; set; }
        public LikesMessage likesMessage { get; set; }
        public bool isBookmarkedByCurrentUser { get; set; }
        public bool isDeleteRestricted { get; set; }
        public bool isLikedByCurrentUser { get; set; }
        public object moderationFlags { get; set; }
        public MyLike myLike { get; set; }
        public object attachment { get; set; }
        public OriginalFeedItem originalFeedItem { get; set; }
        public OriginalFeedItemActor originalFeedItemActor { get; set; }
        public bool @event { get; set; }
        public string visibility { get; set; }
    }
}