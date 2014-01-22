using System.Threading.Tasks;
using Salesforce.Chatter.Models;

namespace Salesforce.Chatter
{
    public interface IChatterClient
    {
        Task<T> Feeds<T>();
        Task<T> Me<T>();
        Task<T> PostFeedItem<T>(FeedItemInput feedItemInput, string userId);
        Task<T> PostFeedItemComment<T>(FeedItemInput envelope, string feedId);
        Task<T> LikeFeedItem<T>(string feedId);
        Task<T> ShareFeedItem<T>(string feedId, string userId);
        Task<T> GetMyNewsFeed<T>(string query = "");
        Task<T> GetGroups<T>();
        Task<T> GetGroupFeed<T>(string groupId);
    }
}