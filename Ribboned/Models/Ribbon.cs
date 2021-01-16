using System;

namespace Ribboned.Models
{
    public class Ribbon
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SourceId { get; set; }
        public int UserProfileId { get; set; }
        public string URL { get; set; }
        public DateTime DateCreated { get; set; }
        public int Duration { get; set; }
        Category Category { get; set; }
        Source Source { get; set; }
        UserProfile UserProfile { get; set; }
    }
}
