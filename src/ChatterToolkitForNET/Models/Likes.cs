using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Likes
    {
        public int total { get; set; }
        public List<Like> likes { get; set; }
        public string currentPageUrl { get; set; }
        public object nextPageUrl { get; set; }
        public object previousPageUrl { get; set; }
    }
}