using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolkitForNET;
using NUnit.Framework;

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
        
        [Test]
        public async void Chatter_IsNotNull()
        {
            var auth = new AuthClient();
            await auth.Authenticate(_consumerKey, _consumerSecret, _username, _password, _tokenRequestEndpointUrl);

            var client = new ChatterClient(auth.ApiVersion, auth.InstanceUrl, auth.AccessToken);
            var chatter = await client.Chatter();

            Assert.IsNotNull(chatter);
        }

        [Test]
        public async void Chatter_Feeds_IsNotNull()
        {
            var auth = new AuthClient();
            await auth.Authenticate(_consumerKey, _consumerSecret, _username, _password, _tokenRequestEndpointUrl);

            var client = new ChatterClient(auth.ApiVersion, auth.InstanceUrl, auth.AccessToken);
            var feeds = await client.Feeds();

            Assert.IsNotNull(feeds);
        }
    }
}
