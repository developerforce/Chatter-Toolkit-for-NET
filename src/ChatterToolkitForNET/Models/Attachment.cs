using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Attachment
    {
        public string attachmentType { get; set; }
        public List<string> pollChoices { get; set; }
    }
}