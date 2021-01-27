using System;
using System.Collections.Generic;

namespace Ribboned.Models
{
    public class Ribbon
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public int CategoryId { get; set; }
        public int SourceId { get; set; }
        public string URL { get; set; }
        public DateTime DateCreated { get; set; }
        public int DurationSeconds { get; set; }
        public List<Snag> Snags { get; set; }
        public Category Category { get; set; }
    }
}
