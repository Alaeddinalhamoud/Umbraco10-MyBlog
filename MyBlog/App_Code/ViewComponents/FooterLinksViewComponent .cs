using Microsoft.AspNetCore.Mvc;
using MyBlog.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyBlog.ViewComponents
{
    [ViewComponent]
    public class FooterLinksViewComponent : ViewComponent
    {
        private readonly UmbracoHelper umbracoHelper;
        private readonly ILogger<FooterLinksViewComponent> logger;
        public FooterLinksViewComponent(UmbracoHelper umbracoHelper, ILogger<FooterLinksViewComponent> logger)
        {
            this.umbracoHelper = umbracoHelper;
            this.logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            List<FooterLinkView> footerLinks = new();

            try
            {
                var homePage = umbracoHelper?.ContentAtRoot()?
                    .FirstOrDefault(x => x.IsDocumentType("home")
                                 && x.IsVisible()) as Home;

                if (homePage is null) return View(footerLinks);

                foreach (var item in homePage?.FooterLinks)
                {


                    footerLinks?.Add(new FooterLinkView
                    {
                        Name = item?.Name,
                        Url = item?.Url,
                        Target = item?.Target
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(FooterLinksViewComponent)}");
            }
            return View(footerLinks);
        }
    }
}
