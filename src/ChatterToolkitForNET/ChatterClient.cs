using System.Threading.Tasks;
using ChatterToolkitForNET.Models;
using CommonToolkitForNET;

namespace ChatterToolkitForNET
{
    public class ChatterClient : IChatterClient
    {
        public string ApiVersion { get; set; }
        public string InstanceUrl { get; set; }
        public string AccessToken { get; set; }
        
        private static ToolkitHttpClient _toolkitHttpClient;

        public ChatterClient(string instanceUrl, string accessToken, string apiVersion)
        {
            this.InstanceUrl = instanceUrl;
            this.AccessToken = accessToken;
            this.ApiVersion = apiVersion;

            const string userAgent = "chatter-toolkit-dotnet";

            _toolkitHttpClient = new ToolkitHttpClient(instanceUrl, apiVersion, accessToken, userAgent);
        }
        
        public async Task<Chatter> Chatter()
        {
            var chatter = await _toolkitHttpClient.HttpGet<Chatter>("chatter");
            return chatter;
        }

        public async Task<T> Feeds<T>()
        {
            var feeds = await _toolkitHttpClient.HttpGet<T>("chatter/feeds");
            return feeds;
        }

        public async Task<T> Me<T>()
        {
            var me = await _toolkitHttpClient.HttpGet<T>("chatter/users/me");
            return me;
        }

        public async Task<T> PostFeedItem<T>(FeedItemInput feedItemInput, string userId)
        {
            var feedItem = await _toolkitHttpClient.HttpPost<T>(feedItemInput, string.Format("chatter/feeds/news/{0}/feed-items", userId));
            return feedItem;
        }

        public async Task<T> PostFeedItemComment<T>(FeedItemInput envelope, string feedId)
        {
            var feedItem = await _toolkitHttpClient.HttpPost<T>(envelope, string.Format("chatter/feed-items/{0}/comments", feedId));
            return feedItem;
        }

        public async Task<T> LikeFeedItem<T>(string feedId)
        {
            var like = await _toolkitHttpClient.HttpPost<T>(null, string.Format("chatter/feed-items/{0}/likes", feedId));
            return like;
        }
    }
}
