namespace Ribboned.Models
{
    public class RibbonSnag
    {
        public int Id { get; set; }
        public int RibbonId { get; set; }
        public int SnagId { get; set; }
        Ribbon Ribbon { get; set; }
        Snag Snag { get; set; }
}
