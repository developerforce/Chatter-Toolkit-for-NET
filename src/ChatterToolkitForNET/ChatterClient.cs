using System.Net.Http;
using System.Threading.Tasks;
using Salesforce.Chatter.Models;
using Salesforce.Common;

namespace Salesforce.Chatter
{
    public class ChatterClient : IChatterClient
    {
        private static ServiceHttpClient _serviceHttpClient;
        private static string _userAgent = "common-libraries-dotnet";

        public ChatterClient(string instanceUrl, string accessToken, string apiVersion) 
            : this (instanceUrl, accessToken, apiVersion, new HttpClient())
        {
        }

        public ChatterClient(string instanceUrl, string accessToken, string apiVersion, HttpClient httpClient)
        {
            _serviceHttpClient = new ServiceHttpClient(instanceUrl, apiVersion, accessToken, _userAgent, httpClient);
        }
        
        public async Task<T> Feeds<T>()
        {
            var feeds = await _serviceHttpClient.HttpGet<T>("chatter/feeds");
            return feeds;
        }

        public async Task<T> Me<T>()
        {
            var me = await _serviceHttpClient.HttpGet<T>("chatter/users/me");
            return me;
        }

        public async Task<T> PostFeedItem<T>(FeedItemInput feedItemInput, string userId)
        {
            var feedItem = await _serviceHttpClient.HttpPost<T>(feedItemInput, string.Format("chatter/feeds/news/{0}/feed-items", userId));
            return feedItem;
        }

        public async Task<T> PostFeedItemComment<T>(FeedItemInput envelope, string feedId)
        {
            var feedItem = await _serviceHttpClient.HttpPost<T>(envelope, string.Format("chatter/feed-items/{0}/comments", feedId));
            return feedItem;
        }

        public async Task<T> LikeFeedItem<T>(string feedId)
        {
            var like = await _serviceHttpClient.HttpPost<T>(null, string.Format("chatter/feed-items/{0}/likes", feedId));
            return like;
        }

        public async Task<T> ShareFeedItem<T>(string feedId, string userId)
        {
            var sharedFeedItem = new SharedFeedItem {originalFeedItemId = feedId};

            var feedItem = await _serviceHttpClient.HttpPost<T>(sharedFeedItem, string.Format("chatter/feeds/user-profile/{0}/feed-items", userId));
            return feedItem;
        }

        public async Task<T> GetMyNewsFeed<T>(string query = "")
        {
            var url = "chatter/feeds/news/me/feed-items";

            if (!string.IsNullOrEmpty(query))
                url += string.Format("?q={0}",query);
                
            var myNewsFeed = await _serviceHttpClient.HttpGet<T>(url);

            return myNewsFeed;
        }

        public async Task<T> GetGroups<T>()
        {
            var groups = await _serviceHttpClient.HttpGet<T>("chatter/groups");
            return groups;
        }

        public async Task<T> GetGroupFeed<T>(string groupId)
        {
            var groupFeed = await _serviceHttpClient.HttpGet<T>(string.Format("chatter/feeds/record/{0}/feed-items", groupId));
            return groupFeed;
        }
    }
}
