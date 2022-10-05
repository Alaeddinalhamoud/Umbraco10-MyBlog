using MyBlog.Notifications;
using Umbraco.Cms.Core.Notifications;

//https://our.umbraco.com/documentation/Reference/Notifications/ 

namespace MyBlog.Composers
{
    public static partial class UmbracoBuilder
    {
        public static IUmbracoBuilder AddCustomNotificationServices(this IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ContentPublishingNotification, GoogleSearchAPIKeyNotification>();
            builder.AddNotificationHandler<ContentPublishingNotification, ContactUsEmailSettingsNotification>();

            return builder;
        }
    }
}
