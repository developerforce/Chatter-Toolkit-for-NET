using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class GroupPage
    {
        public string currentPageUrl { get; set; }
        public List<Group> groups { get; set; }
        public string nextPageUrl { get; set; }
        public string previousPageUrl { get; set; }
    }
}