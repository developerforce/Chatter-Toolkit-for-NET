using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Groups
    {
        public string currentPageUrl { get; set; }
        public object nextPageUrl { get; set; }
        public object previousPageUrl { get; set; }
        public List<Group> groups { get; set; }
    }
}