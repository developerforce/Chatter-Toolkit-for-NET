namespace ChatterToolkitForNET.Models
{
    public class User
    {
        public bool isActive { get; set; }
        public string name { get; set; }
        public object title { get; set; }
        public string companyName { get; set; }
        public bool isInThisCommunity { get; set; }
        public object mySubscription { get; set; }
        public Photo photo { get; set; }
        public string userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public Motif motif { get; set; }
        public string type { get; set; }
    }
}