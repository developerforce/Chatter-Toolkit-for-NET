using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Groups
    {
        public string currentPageUrl { get; set; }
        public List<Group> groups { get; set; }
        public string nextPageUrl { get; set; }
        public string previousPageUrl { get; set; }
    }
}