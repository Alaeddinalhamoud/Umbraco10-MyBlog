using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewComponentModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace MyBlog.ViewComponents
{
    [ViewComponent]
    public class MetaTagsViewComponent : ViewComponent
    {
        private readonly IUmbracoContextAccessor context;
        private readonly ILogger<MetaTagsViewComponent> logger;
        public MetaTagsViewComponent(IUmbracoContextAccessor context, ILogger<MetaTagsViewComponent> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public IViewComponentResult Invoke()
        {
            MetaTagsView metaTags = new();
            try
            {
                var content = context.GetRequiredUmbracoContext().PublishedRequest?.PublishedContent;

                if (content is null) return View(metaTags);

                metaTags.Description = content?.Value<string>("description");
                metaTags.Author = content?.Value<string>("author");
                metaTags.Keywords = string.Join(", ", content?.Value<string[]>("keywords"));
                metaTags.Title = $"{content?.AncestorsOrSelf()?.FirstOrDefault(x => x.IsDocumentType("home"))?.Value<string>("siteName")} - {content?.Value<string>("title")}";
                metaTags.OGImage = string.IsNullOrWhiteSpace(content?.Value<IPublishedContent>("ogImage")?.Url()) ?
                           content?.Value<IPublishedContent>("pageBanner")?.Url() :
                           content?.Value<IPublishedContent>("ogImage")?.Url();

                metaTags.OGUrl = content?.Url();
                metaTags.OGType = content?.Value<string>("ogtype");
                metaTags.TwitterCard = content?.Value<string>("twitterCard");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error While Processing {nameof(MetaTagsViewComponent)}");
            }
            return View(metaTags);
        }

    }
}
