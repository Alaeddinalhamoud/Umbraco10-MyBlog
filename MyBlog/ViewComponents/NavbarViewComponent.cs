using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewComponentModels;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyBlog.ViewComponents
{
    [ViewComponent]
    public class NavbarViewComponent : ViewComponent
    {
        private readonly UmbracoHelper umbracoHelper;
        private readonly ILogger<NavbarViewComponent> logger;
        public NavbarViewComponent(UmbracoHelper umbracoHelper, ILogger<NavbarViewComponent> logger)
        {
            this.umbracoHelper = umbracoHelper;
            this.logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            NavbarView navbarItem = new();

            try
            {
                var homePage = umbracoHelper?.ContentAtRoot()?
                    .FirstOrDefault(x => x.IsDocumentType("home")
                                 && x.IsVisible()) as Home;

                if (homePage is null) return View(navbarItem);

                navbarItem.SiteName = homePage?.SiteName;

                foreach (var item in homePage?.Children)
                {
                    if (item?.Value<bool>("displayOnNavbar") ?? false)
                    {
                        navbarItem.NavbarChildren.Add(new NavbarChild
                        {
                            Name = item?.Name,
                            Url = item?.Url()
                        });
                    }                   
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(NavbarViewComponent)}");
            }
            return View(navbarItem);
        }
    }
}
