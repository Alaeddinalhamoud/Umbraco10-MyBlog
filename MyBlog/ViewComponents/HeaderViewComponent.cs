using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewComponentModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace MyBlog.ViewComponents
{
    [ViewComponent]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IUmbracoContextAccessor context;
        private readonly ILogger<HeaderViewComponent> logger;
        public HeaderViewComponent(IUmbracoContextAccessor context, ILogger<HeaderViewComponent> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public IViewComponentResult Invoke()
        {
            HeaderView headerView = new();
            try
            {
                var content = context.GetRequiredUmbracoContext().PublishedRequest?.PublishedContent;

                if (content is null) return View(headerView);


                headerView.Title = content?.Value<string>("title");
                headerView.SubTitle = content?.Value<string>("subTitle");
                headerView.ImageUrl = content?.Value<IPublishedContent>("pageBanner")?.Url();
                headerView.IsBlog = content.IsDocumentType("blog");
                headerView.CreatedBy = content?.CreatorName();
                headerView.CreatedDate = content?.CreateDate.ToString("D");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error While Processing {nameof(HeaderViewComponent)}");
            }

            return View(headerView);
        }

    }
}
