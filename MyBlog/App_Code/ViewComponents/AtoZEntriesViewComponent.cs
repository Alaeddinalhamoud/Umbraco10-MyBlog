using Microsoft.AspNetCore.Mvc;
using MyBlog.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;

namespace MyBlog.App_Code.ViewComponents
{
    [ViewComponent]
    public class AtoZPageViewComponent : ViewComponent
    {
        private readonly UmbracoHelper umbracoHelper;
        private readonly ILogger<AtoZPageViewComponent> logger;
        public AtoZPageViewComponent(UmbracoHelper umbracoHelper,
                                        ILogger<AtoZPageViewComponent> logger)
        {
            this.umbracoHelper = umbracoHelper;
            this.logger = logger;
        }
        public IViewComponentResult Invoke()
        {
            var azPages = new SortedDictionary<string, AtoZView>();

            try
            {
                string letterQuery = HttpContext?.Request.Query["letter"].ToString();

                string letter = !string.IsNullOrWhiteSpace(letterQuery) ?
                                letterQuery.Substring(0, 1) : "A";

                var sitePages = umbracoHelper?.ContentAtRoot()?
                            .FirstOrDefault()?
                            .Descendants()?
                            .Where(x => x.IsVisible()
                                && !x.Value<bool>("displayOnAToZ"));

                if (sitePages is null)
                    return View(azPages);

                foreach (var page in sitePages ?? new List<IPublishedContent>())
                {
                    string title = page?.Value<string>("title");

                    if (!azPages.ContainsKey(title))
                    {
                        azPages.Add(title, new AtoZView()
                        {
                            Url = $"{page?.Url()}",
                            Id = page.Id,
                            Title = title,
                            Letter = letter.ToUpper()
                        });
                    }
                }

                if (azPages?.Any() ?? false)
                {
                    return View(new SortedDictionary<string, AtoZView>(
                        azPages.Where(x => x.Key.ToLower().StartsWith(letter.ToLower()))
                               .ToDictionary(x => x.Key, x => x.Value)));
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, $"Error While processing {nameof(AtoZPageViewComponent)}");
            }
            return View(azPages);
        }
    }
}
