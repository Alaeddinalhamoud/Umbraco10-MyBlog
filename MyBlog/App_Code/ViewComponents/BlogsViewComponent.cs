using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewComponentModels;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyBlog.ViewComponents
{
    [ViewComponent]
    public class BlogsViewComponent : ViewComponent
    {
        private readonly ILogger<BlogsViewComponent> logger;
        private readonly UmbracoHelper umbracoHelper;
        public BlogsViewComponent(ILogger<BlogsViewComponent> logger, UmbracoHelper umbracoHelper)
        {
            this.logger = logger;
            this.umbracoHelper = umbracoHelper;
        }
        public IViewComponentResult Invoke()
        {
            List<BlogsView> blogItems = new();
            try
            {
                var content = umbracoHelper?.ContentAtRoot()?
                    .FirstOrDefault(x => x.IsDocumentType("home"))?
                    .Children()?
                    .FirstOrDefault(x => x.IsVisible()
                             && x.IsDocumentType("blogs")) as Blogs;

                if (content == null) return View(blogItems);

                foreach (Blog item in content.Children() ?? new List<Blog>())
                {
                    blogItems?.Add(new BlogsView
                    {
                        Title = item?.Title,
                        SubTitle = item?.SubTitle,
                        BlogUrl = item?.Url(),
                        CreatedBy = item?.CreatorName(),
                        CreatedDate = item?.CreateDate.ToString("D")
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(BlogsViewComponent)}");
            }
            return View(blogItems);
        }
    }
}
