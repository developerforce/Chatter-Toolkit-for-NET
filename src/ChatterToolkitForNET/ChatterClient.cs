using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChatterToolkitForNET.Models;
using ForceToolkitForNET;
using ForceToolkitForNET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatterToolkitForNET
{
    public class ChatterClient : IChatterClient
    {
        public ChatterClient(string apiVersion, string instanceUrl, string accessToken)
        {
            this.ApiVersion = apiVersion;
            this.InstanceUrl = instanceUrl;
            this.AccessToken = accessToken;
        }

        public string ApiVersion { get; set; }
        public string InstanceUrl { get; set; }
        public string AccessToken { get; set; }

        public async Task<Chatter> Chatter()
        {
            var url = FormatUrl("chatter");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(string.Format("chatter-toolkit-dotnet/{0}", ApiVersion));

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get
                };

                request.Headers.Add("Authorization", "Bearer " + AccessToken);

                var responseMessage = await client.SendAsync(request);
                var response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jObject = JObject.Parse(response);

                    var r = JsonConvert.DeserializeObject<Chatter>(jObject.ToString());
                    return r;
                }

                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                throw new ForceException(errorResponse.errorCode, errorResponse.message);
            }
        }

        public async Task<object> Feeds()
        {
            var url = FormatUrl("chatter/feeds");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(string.Format("chatter-toolkit-dotnet/{0}", ApiVersion));

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get
                };

                request.Headers.Add("Authorization", "Bearer " + AccessToken);

                var responseMessage = await client.SendAsync(request);
                var response = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jObject = JObject.Parse(response);

                    var r = JsonConvert.DeserializeObject<object>(jObject.ToString());
                    return r;
                }

                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                throw new ForceException(errorResponse.errorCode, errorResponse.message);
            }
        }

        protected string FormatUrl(string resourceName)
        {
            return string.Format("{0}/services/data/{1}/{2}", InstanceUrl, ApiVersion, resourceName);
        }
    }
}
