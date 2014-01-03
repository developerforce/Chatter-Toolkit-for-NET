using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolkitForNET;
using NUnit.Framework;
using ChatterToolkitForNET.Models;

namespace ChatterToolkitForNET.FunctionalTests
{
    public class ChatterClientTests
    {
        private static string _tokenRequestEndpointUrl = ConfigurationSettings.AppSettings["TokenRequestEndpointUrl"];
        private static string _securityToken = ConfigurationSettings.AppSettings["SecurityToken"];
        private static string _consumerKey = ConfigurationSettings.AppSettings["ConsumerKey"];
        private static string _consumerSecret = ConfigurationSettings.AppSettings["ConsumerSecret"];
        private static string _username = ConfigurationSettings.AppSettings["Username"];
        private static string _password = ConfigurationSettings.AppSettings["Password"] + _securityToken;

        public async Task<ChatterClient> GetChatterClient()
        {
            var auth = new AuthClient();
            await auth.Authenticate(_consumerKey, _consumerSecret, _username, _password, _tokenRequestEndpointUrl);

            var client = new ChatterClient(auth.ApiVersion, auth.InstanceUrl, auth.AccessToken);
            return client;
        }

        [Test]
        public async void Chatter_IsNotNull()
        {
            var chatter = await GetChatterClient();

            Assert.IsNotNull(chatter);
        }

        [Test]
        public async void Chatter_Feeds_IsNotNull()
        {
            var chatter = await GetChatterClient();
            var feeds = await chatter.Feeds<object>();

            Assert.IsNotNull(feeds);
        }

        [Test]
        public async void Chatter_Users_Me_IsNotNull()
        {
            var chatter = await GetChatterClient();
            var me = await chatter.Me<Me>();

            Assert.IsNotNull(me);
        }

        [Test]
        public async void Chatter_Users_Me_Id_IsNotNull()
        {
            var chatter = await GetChatterClient();
            var me = await chatter.Me<Me>();

            Assert.IsNotNull(me.id);
        }

        [Test]
        public async void Chatter_PostFeedItem()
        {
            var chatter = await GetChatterClient();
            var feedItem = await postFeedItem(chatter);
            Assert.IsNotNull(feedItem);
        }

        [Test]
        public async void Chatter_Add_Comment()
        {
            var chatter = await GetChatterClient();
            var feedItem = await postFeedItem(chatter);
            var feedId = feedItem.id;

            var messageSegment = new MessageSegment()
            {
                text = "Comment testing 1, 2, 3",
                type = "Text"
            };

            var body = new FeedItemInputBody { messageSegments = new List<MessageSegment> { messageSegment } };
            var commentInput = new FeedItemInput()
            {
                attachment = null,
                body = body
            };

            var comment = await chatter.PostFeedItemComment<Comment>(commentInput, feedId);
            Assert.IsNotNull(comment);
        }

        [Test]
        public async void Chatter_Add_Comment_With_Mention_IsNotNull()
        {
            var chatter = await GetChatterClient();
            var feedItem = await postFeedItem(chatter);
            var feedId = feedItem.id;

            var me = await chatter.Me<Me>();
            var meId = me.id;

            var messageSegment1 = new MessageSegment()
            {
                id = meId,
                type = "mention",
            };

            var messageSegment2 = new MessageSegment()
            {
                text = "Comment testing 1, 2, 3",
                type = "Text",
            };

            var body = new FeedItemInputBody
            {
                messageSegments = new List<MessageSegment>
                {
                    messageSegment1, 
                    messageSegment2
                }
            };
            var commentInput = new FeedItemInput()
            {
                attachment = null,
                body = body
            };

            var comment = await chatter.PostFeedItemComment<Comment>(commentInput, feedId);
            Assert.IsNotNull(comment);
        }

        [Test]
        public async void Chatter_Like_FeedItem_IsNotNull()
        {
            var chatter = await GetChatterClient();
            var feedItem = await postFeedItem(chatter);
            var feedId = feedItem.id;
            
            var liked = await chatter.LikeFeedItem<Liked>(feedId);

            Assert.IsNotNull(liked);
        }

        #region private functions
        private async Task<FeedItem> postFeedItem(ChatterClient chatter)
        {
            var me = await chatter.Me<Me>();
            var id = me.id;

            var messageSegment = new MessageSegment()
            {
                text = "Testing 1, 2, 3",
                type = "Text"
            };

            var body = new FeedItemInputBody { messageSegments = new List<MessageSegment> { messageSegment } };
            var feedItemInput = new FeedItemInput()
            {
                attachment = null,
                body = body
            };

            var feedItem = await chatter.PostFeedItem<FeedItem>(feedItemInput, id);
            return feedItem;
        }
        #endregion

    }
}
