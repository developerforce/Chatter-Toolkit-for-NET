namespace Salesforce.Chatter.Models
{
    public class Item
    {
        public Actor actor { get; set; } // The entity that created the item. This can be a RecordSummary, a UserSummary, or an UnauthenticatedUser (i.e. Chatter customer).
        public object attachment { get; set; } // Depends on the type value of the attachment.
        public FeedItemBody body { get; set; }
        public bool canShare { get; set; }
        public ClientInfo clientInfo { get; set; }
        public Comments comments { get; set; }
        public string createdDate { get; set; }
        public bool @event { get; set; }
        public string id { get; set; }
        public bool isBookmarkedByCurrentUser { get; set; }
        public bool isDeleteRestricted { get; set; }
        public bool isLikedByCurrentUser { get; set; }
        public Likes likes { get; set; }
        public LikesMessage likesMessage { get; set; }
        public object moderationFlags { get; set; }
        public string modifiedDate { get; set; }
        public MyLike myLike { get; set; }
        public Reference originalFeedItem { get; set; }
        public OriginalFeedItemActor originalFeedItemActor { get; set; }
        public Parent parent { get; set; }
        public string photoUrl { get; set; }
        public Preamble preamble { get; set; }
        public string relativeCreatedDate { get; set; }
        public Topics topics { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }
}