using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class FeedModifiedInfo
    {
        public List<Item> items { get; set; }
        public object isModifiedToken { get; set; }
        public object isModifiedUrl { get; set; }
        public string currentPageUrl { get; set; }
        public string nextPageUrl { get; set; }
    }
}