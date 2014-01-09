using System.Collections.Generic;

namespace Salesforce.Chatter.Models
{
    public class Me
    {
        public Address address { get; set; }
        public object managerId { get; set; }
        public object aboutMe { get; set; }
        public ChatterActivity chatterActivity { get; set; }
        public int followersCount { get; set; }
        public FollowingCounts followingCounts { get; set; }
        public object managerName { get; set; }
        public object thanksReceived { get; set; }
        public string email { get; set; }
        public int groupCount { get; set; }
        public List<object> phoneNumbers { get; set; }
        public ChatterInfluence chatterInfluence { get; set; }
        public bool isActive { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public Photo photo { get; set; }
        public object mySubscription { get; set; }
        public bool isInThisCommunity { get; set; }
        public string userType { get; set; }
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object title { get; set; }
        public string id { get; set; }
        public Motif motif { get; set; }
        public string url { get; set; }
        public string type { get; set; }
    }
}