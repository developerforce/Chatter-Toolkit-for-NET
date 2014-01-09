namespace Salesforce.Chatter.Models
{
    public class Group
    {
        public Information information { get; set; }
        public int fileCount { get; set; }
        public object pendingRequests { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
        public int memberCount { get; set; }
        public Photo photo { get; set; }
        public bool canHaveChatterGuests { get; set; }
        public bool isAutoArchiveDisabled { get; set; }
        public MySubscription mySubscription { get; set; }
        public string myRole { get; set; }
        public object emailToChatterAddress { get; set; }
        public string lastFeedItemPostDate { get; set; }
        public bool isArchived { get; set; }
        public object community { get; set; }
        public string visibility { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public Motif motif { get; set; }
        public string url { get; set; }
        public string type { get; set; }
    }
}