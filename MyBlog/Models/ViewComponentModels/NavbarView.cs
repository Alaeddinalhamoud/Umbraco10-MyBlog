namespace MyBlog.Models.ViewComponentModels
{
    public class NavbarView
    {
        public string SiteName { get; set; }
        public List<NavbarChild> NavbarChildren { get; set; } = new List<NavbarChild>();
    }

    public class NavbarChild
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
