using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForceToolkitForNET;
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
        public async void Auth_ValidCreds_HasApiVersion()
        {
            var client = new ForceClient();

            Assert.IsNotNullOrEmpty(client.ApiVersion);
        }

        [Test]
        public async void Auth_ValidCreds_HasAccessToken()
        {
            var client = new ForceClient();
            await client.Authenticate(_consumerKey, _consumerSecret, _username, _password, _tokenRequestEndpointUrl);

            Assert.IsNotNullOrEmpty(client.AccessToken);
        }

        [Test]
        public async void Auth_ValidCreds_HasInstanceUrl()
        {
            var client = new ForceClient();
            await client.Authenticate(_consumerKey, _consumerSecret, _username, _password, _tokenRequestEndpointUrl);

            Assert.IsNotNullOrEmpty(client.InstanceUrl);
        }

        [Test]
        public async void Chatter_IsNotNull()
        {
            var forceClient = new ForceClient();
            await forceClient.Authenticate(_consumerKey, _consumerSecret, _username, _password, _tokenRequestEndpointUrl);

            var client = new ChatterClient(forceClient.ApiVersion, forceClient.InstanceUrl, forceClient.AccessToken);
            var chatter = await client.Chatter();

            Assert.IsNotNull(chatter);
        }

        [Test]
        public async void Chatter_Feeds_IsNotNull()
        {
            var forceClient = new ForceClient();
            await forceClient.Authenticate(_consumerKey, _consumerSecret, _username, _password, _tokenRequestEndpointUrl);

            var client = new ChatterClient(forceClient.ApiVersion, forceClient.InstanceUrl, forceClient.AccessToken);
            var feeds = await client.Feeds();

            Assert.IsNotNull(feeds);
        }
    }
}
