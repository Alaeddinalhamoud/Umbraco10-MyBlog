using Microsoft.AspNetCore.Mvc;
using MyBlog.App_Code.Pagination;
using MyBlog.Models.ViewComponentModels;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
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
        public IViewComponentResult Invoke(int? page = 0)
        {
            List<BlogsView> blogItems = new();
            int pageSize = 3;
            try
            {
                var content = umbracoHelper?.ContentAtRoot()?
                    .FirstOrDefault(x => x.IsDocumentType("home"))?
                    .Children()?
                    .FirstOrDefault(x => x.IsVisible()
                             && x.IsDocumentType("blogs")) as Blogs;

                if (content == null) return View(blogItems);

                pageSize = content.NumberOfBlogs.Equals(0) ? pageSize : content.NumberOfBlogs;

                foreach (Blog item in content?.Children() ?? new List<Blog>())
                {
                    blogItems?.Add(new BlogsView
                    {
                        Title = item?.Title,
                        SubTitle = item?.SubTitle,
                        BlogUrl = item?.Url(),
                        CreatedBy = item?.CreatorName(),
                        AuthorUrl = item?.AuthorPageUrl?.Url(),
                        CreatedDate = item?.CreateDate.ToString("D")
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(BlogsViewComponent)}");
            }

            return View(PaginatedList<BlogsView>.Create(blogItems.AsQueryable(), page ?? 1, pageSize));
        }
    }
}
