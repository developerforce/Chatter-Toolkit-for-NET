namespace Salesforce.Chatter.Models
{
    public class Group
    {
        // This class matches the GroupDetail response body, 
        // but is very similar to the Group response body in the API docs.

        public bool canHaveChatterGuests { get; set; }
        public Reference community { get; set; }
        public string description { get; set; }
        public string emailToChatterAddress { get; set; }
        public int fileCount { get; set; }
        public string id { get; set; }
        public bool isArchived { get; set; }
        public bool isAutoArchiveDisabled { get; set; }
        public Information information { get; set; }
        public string lastFeedItemPostDate { get; set; }
        public int memberCount { get; set; }
        public Motif motif { get; set; }
        public string myRole { get; set; }
        public Reference mySubscription { get; set; }
        public string name { get; set; }
        public User owner { get; set; }
        public int pendingRequests { get; set; }
        public Photo photo { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }
}