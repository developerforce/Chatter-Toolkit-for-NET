using System.Collections.Generic;

namespace ChatterToolkitForNET.Models
{
    public class Comments
    {
        public int total { get; set; }
        public List<Comment> comments { get; set; }
        public string currentPageUrl { get; set; }
        public object nextPageUrl { get; set; }
    }
}