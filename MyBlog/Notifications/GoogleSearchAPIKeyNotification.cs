using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace MyBlog.Notifications
{
    public class GoogleSearchAPIKeyNotification : INotificationHandler<ContentPublishingNotification>
    {
        private readonly ILogger<GoogleSearchAPIKeyNotification> logger;
        public GoogleSearchAPIKeyNotification(ILogger<GoogleSearchAPIKeyNotification> logger) =>
            this.logger = logger;

        public void Handle(ContentPublishingNotification notification)
        {
            try
            {
                foreach (var node in notification.PublishedEntities)
                {
                    if (node.ContentType.Alias.Equals("search"))
                    {
                        var googleSearchAPIKey = node.GetValue<string>("googleCustomSearchAPIKey");
                        var enableGoogleSearch = node.GetValue<bool>("enableGoogleSearch");

                        if (enableGoogleSearch && string.IsNullOrWhiteSpace(googleSearchAPIKey))
                        {
                            notification.CancelOperation(new EventMessage("Cancelled", "Please provide the API Key", EventMessageType.Error));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(GoogleSearchAPIKeyNotification)}");
            }
        }
    }
}
