namespace Portfolio.Models
{
    public class ProjectItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameNormalised { get; set; }
        public string ShortDescription { get; set; }
        public string ThumbnailImage { get; set; }
        public bool IsVisible { get; set; }
    }
}