namespace Salesforce.Chatter.Models
{
    public class Address
    {
        public object state { get; set; }
        public string country { get; set; }
        public string formattedAddress { get; set; }
        public string zip { get; set; }
        public object street { get; set; }
        public object city { get; set; }
    }
}