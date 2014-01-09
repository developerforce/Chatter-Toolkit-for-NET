namespace Salesforce.Chatter.Models
{
    public class Photo
    {
        public string url { get; set; }
        public string largePhotoUrl { get; set; }
        public object photoVersionId { get; set; }
        public string smallPhotoUrl { get; set; }
        public string fullEmailPhotoUrl { get; set; }
        public string standardEmailPhotoUrl { get; set; }
    }
}