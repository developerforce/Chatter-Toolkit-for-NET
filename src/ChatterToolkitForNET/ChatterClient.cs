using System.Threading.Tasks;
using Salesforce.Chatter.Models;
using Salesforce.Common;

namespace Salesforce.Chatter
{
    public class ChatterClient : IChatterClient
    {
        public string ApiVersion { get; set; }
        public string InstanceUrl { get; set; }
        public string AccessToken { get; set; }
        
        private static SalesforceHttpClient _httpClient;

        public ChatterClient(string instanceUrl, string accessToken, string apiVersion)
        {
            this.InstanceUrl = instanceUrl;
            this.AccessToken = accessToken;
            this.ApiVersion = apiVersion;

            const string userAgent = "chatter-toolkit-dotnet";

            _httpClient = new SalesforceHttpClient(instanceUrl, apiVersion, accessToken, userAgent);
        }
        
        public async Task<T> Feeds<T>()
        {
            var feeds = await _httpClient.HttpGet<T>("chatter/feeds");
            return feeds;
        }

        public async Task<T> Me<T>()
        {
            var me = await _httpClient.HttpGet<T>("chatter/users/me");
            return me;
        }

        public async Task<T> PostFeedItem<T>(FeedItemInput feedItemInput, string userId)
        {
            var feedItem = await _httpClient.HttpPost<T>(feedItemInput, string.Format("chatter/feeds/news/{0}/feed-items", userId));
            return feedItem;
        }

        public async Task<T> PostFeedItemComment<T>(FeedItemInput envelope, string feedId)
        {
            var feedItem = await _httpClient.HttpPost<T>(envelope, string.Format("chatter/feed-items/{0}/comments", feedId));
            return feedItem;
        }

        public async Task<T> LikeFeedItem<T>(string feedId)
        {
            var like = await _httpClient.HttpPost<T>(null, string.Format("chatter/feed-items/{0}/likes", feedId));
            return like;
        }

        public async Task<T> ShareFeedItem<T>(string feedId, string userId)
        {
            var sharedFeedItem = new SharedFeedItem {originalFeedItemId = feedId};

            var feedItem = await _httpClient.HttpPost<T>(sharedFeedItem, string.Format("chatter/feeds/user-profile/{0}/feed-items", userId));
            return feedItem;
        }

        public async Task<T> GetMyNewsFeed<T>(string query = "")
        {
            var url = "chatter/feeds/news/me/feed-items";

            if (!string.IsNullOrEmpty(query))
                url += string.Format("?q={0}",query);
                
            var myNewsFeed = await _httpClient.HttpGet<T>(url);

            return myNewsFeed;
        }

        public async Task<T> GetGroups<T>()
        {
            var groups = await _httpClient.HttpGet<T>("chatter/groups");
            return groups;
        }

        public async Task<T> GetGroupFeed<T>(string groupId)
        {
            var groupFeed = await _httpClient.HttpGet<T>(string.Format("chatter/feeds/record/{0}/feed-items", groupId));
            return groupFeed;
        }
    }
}
