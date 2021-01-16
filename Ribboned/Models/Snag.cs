using System;

namespace Ribboned.Models
{
    public class Snag
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Note { get; set; }
        public int Seconds { get; set; }
    }
}
