namespace Algorithms.Chapter_3.Models
{
    public class Box
    {
        public bool HasKey { get; set; }
        public List<Box> Boxes { get; set; } = [];
    }
}
