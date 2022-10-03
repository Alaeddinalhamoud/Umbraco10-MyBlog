﻿using MyBlog.Notifications;
using Umbraco.Cms.Core.Notifications;

namespace MyBlog.Composers
{
    public static partial class UmbracoBuilder
    {
        public static IUmbracoBuilder AddCustomNotificationServices(this IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ContentPublishingNotification, GoogleSearchAPIKeyNotification>();
            return builder;
        }
    }
}
