using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Topics
    {
        public List<object> topics { get; set; }
        public bool canAssignTopics { get; set; }
    }
}