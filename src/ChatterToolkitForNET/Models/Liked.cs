namespace ChatterToolkitForNET.Models
{
    public class Liked
    {
        public string id { get; set; }
        public string url { get; set; }
        public User user { get; set; }
        public LikedItem likedItem { get; set; }
    }
}