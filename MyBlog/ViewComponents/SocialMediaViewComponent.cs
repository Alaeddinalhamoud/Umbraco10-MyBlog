using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewComponentModels;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyBlog.ViewComponents
{
    [ViewComponent]
    public class SocialMediaViewComponent : ViewComponent
    {
        private readonly UmbracoHelper umbracoHelper;
        private readonly ILogger<HeaderViewComponent> logger;
        public SocialMediaViewComponent(UmbracoHelper umbracoHelper, ILogger<HeaderViewComponent> logger)
        {
            this.umbracoHelper = umbracoHelper;
            this.logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            List<SocialMediaView> socialMediaItems = new();

            try
            {
                var homePage = umbracoHelper?.ContentAtRoot()?
                    .FirstOrDefault(x => x.IsDocumentType("home")
                                 && x.IsVisible()) as Home;

                if (homePage is null) return View(socialMediaItems);

                foreach (var item in homePage?.SocialMediaPicker)
                {
                    var socialMediaElement = item.Content as SocialMediaElement;
                    socialMediaItems?.Add(new SocialMediaView
                    {
                        Icon = socialMediaElement?.Icon?.ToString(),
                        SocialMediaUrl = socialMediaElement?.SocialMediaUrl,
                        Target = socialMediaElement?.Target
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(SocialMediaViewComponent)}");
            }
            return View(socialMediaItems);
        }
    }
}
