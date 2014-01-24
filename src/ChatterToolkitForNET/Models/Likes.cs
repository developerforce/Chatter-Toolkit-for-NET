using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Likes
    {
        public string currentPageUrl { get; set; }
        public List<Like> likes { get; set; }
        
        public string nextPageUrl { get; set; }
        public string previousPageUrl { get; set; }
        public int total { get; set; }
    }
}