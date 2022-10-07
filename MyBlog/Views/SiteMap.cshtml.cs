using Umbraco.Cms.Core.Models.PublishedContent;

namespace MyBlog.Views
{
    public static class SiteMapRecursive
    {
        static int maxLevelForSitemap = 4;
        public static IEnumerable<IPublishedContent> GetPages(IPublishedContent node) =>
           node?.Children?.Where(x => x.IsVisible()
                                   && x.Level <= maxLevelForSitemap
                                   && x.Value<bool>("displayOnSitemap"));
    }
}
