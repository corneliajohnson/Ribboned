using System;

namespace Ribboned.Models
{
    public class Snag
    {
        public int Id { get; set; }
        public int RibbonId { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
        public int Seconds { get; set; }
    }
}
