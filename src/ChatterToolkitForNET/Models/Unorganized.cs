using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ChatterToolkitForNET.Models
{
    // me
    public class Address
    {
        public object state { get; set; }
        public string country { get; set; }
        public string formattedAddress { get; set; }
        public string zip { get; set; }
        public object street { get; set; }
        public object city { get; set; }
    }

    public class ChatterActivity
    {
        public int commentCount { get; set; }
        public int commentReceivedCount { get; set; }
        public int likeReceivedCount { get; set; }
        public int postCount { get; set; }
    }

    public class FollowingCounts
    {
        public int records { get; set; }
        public int people { get; set; }
        public int total { get; set; }
    }

    public class ChatterInfluence
    {
        public string percentile { get; set; }
        public int rank { get; set; }
    }

    public class Photo
    {
        public string url { get; set; }
        public string largePhotoUrl { get; set; }
        public object photoVersionId { get; set; }
        public string smallPhotoUrl { get; set; }
        public string fullEmailPhotoUrl { get; set; }
        public string standardEmailPhotoUrl { get; set; }
    }

    public class Motif
    {
        public string color { get; set; }
        public string largeIconUrl { get; set; }
        public string mediumIconUrl { get; set; }
        public string smallIconUrl { get; set; }
    }

    public class Me
    {
        public Address address { get; set; }
        public object managerId { get; set; }
        public object aboutMe { get; set; }
        public ChatterActivity chatterActivity { get; set; }
        public int followersCount { get; set; }
        public FollowingCounts followingCounts { get; set; }
        public object managerName { get; set; }
        public object thanksReceived { get; set; }
        public string email { get; set; }
        public int groupCount { get; set; }
        public List<object> phoneNumbers { get; set; }
        public ChatterInfluence chatterInfluence { get; set; }
        public bool isActive { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public Photo photo { get; set; }
        public object mySubscription { get; set; }
        public bool isInThisCommunity { get; set; }
        public string userType { get; set; }
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object title { get; set; }
        public string id { get; set; }
        public Motif motif { get; set; }
        public string url { get; set; }
        public string type { get; set; }
    }

    // feed item input
    public class Attachment
    {
        public string attachmentType { get; set; }
        public List<string> pollChoices { get; set; }
    }

    public class FeedItemInputBody
    {
        public List<MessageSegment> messageSegments { get; set; }
    }

    public class FeedItemInput
    {
        public Attachment attachment { get; set; }
        public FeedItemInputBody body { get; set; }
    }

    //feed item

    public class Parent
    {
        public bool isActive { get; set; }
        public string name { get; set; }
        public object title { get; set; }
        public string companyName { get; set; }
        public string userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Photo photo { get; set; }
        public object mySubscription { get; set; }
        public bool isInThisCommunity { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public Motif motif { get; set; }
        public string type { get; set; }
    }

    public class ClientInfo
    {
        public string applicationName { get; set; }
        public object applicationUrl { get; set; }
    }

    public class MessageSegment
    {
        public string type { get; set; }
        public string text { get; set; }
        public string id { get; set; }
    }

    public class FeedItemBody
    {
        public string text { get; set; }
        public List<MessageSegment> messageSegments { get; set; }
    }

    public class Topics
    {
        public List<object> topics { get; set; }
        public bool canAssignTopics { get; set; }
    }

    public class Comments
    {
        public int total { get; set; }
        public List<object> comments { get; set; }
        public string currentPageUrl { get; set; }
        public object nextPageUrl { get; set; }
    }

    public class Likes
    {
        public int total { get; set; }
        public List<object> likes { get; set; }
        public string currentPageUrl { get; set; }
        public object nextPageUrl { get; set; }
        public object previousPageUrl { get; set; }
    }

    public class Reference
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class MessageSegment2
    {
        public Reference reference { get; set; }
        public Motif motif { get; set; }
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Preamble
    {
        public string text { get; set; }
        public List<MessageSegment2> messageSegments { get; set; }
    }

    public class Actor
    {
        public bool isActive { get; set; }
        public string name { get; set; }
        public object title { get; set; }
        public string companyName { get; set; }
        public string userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Photo photo { get; set; }
        public object mySubscription { get; set; }
        public bool isInThisCommunity { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public Motif motif { get; set; }
        public string type { get; set; }
    }

    public class FeedItem
    {
        public Parent parent { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string createdDate { get; set; }
        public ClientInfo clientInfo { get; set; }
        public FeedItemBody body { get; set; }
        public string visibility { get; set; }
        public bool @event { get; set; }
        public Topics topics { get; set; }
        public string photoUrl { get; set; }
        public string relativeCreatedDate { get; set; }
        public object likesMessage { get; set; }
        public bool isBookmarkedByCurrentUser { get; set; }
        public bool isDeleteRestricted { get; set; }
        public bool isLikedByCurrentUser { get; set; }
        public object moderationFlags { get; set; }
        public object myLike { get; set; }
        public object attachment { get; set; }
        public object originalFeedItem { get; set; }
        public object originalFeedItemActor { get; set; }
        public bool canShare { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Preamble preamble { get; set; }
        public string modifiedDate { get; set; }
        public Actor actor { get; set; }
    }
    
    //comment response
    public class User
    {
        public bool isActive { get; set; }
        public string name { get; set; }
        public object title { get; set; }
        public string companyName { get; set; }
        public bool isInThisCommunity { get; set; }
        public object mySubscription { get; set; }
        public Photo photo { get; set; }
        public string userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public Motif motif { get; set; }
        public string type { get; set; }
    }

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

    public class Liked
    {
        public string id { get; set; }
        public string url { get; set; }
        public User user { get; set; }
        public LikedItem likedItem { get; set; }
    }

    public class LikedItem
    {
        public string id { get; set; }
        public string url { get; set; }
    }
}
