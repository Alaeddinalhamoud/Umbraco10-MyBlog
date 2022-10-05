using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

//https://our.umbraco.com/documentation/Reference/Notifications/

namespace MyBlog.Notifications
{
    public class ContactUsEmailSettingsNotification : INotificationHandler<ContentPublishingNotification>
    {
        private readonly ILogger<ContactUsEmailSettingsNotification> logger;
        public ContactUsEmailSettingsNotification(ILogger<ContactUsEmailSettingsNotification> logger) =>
            this.logger = logger;

        public void Handle(ContentPublishingNotification notification)
        {
            try
            {
                foreach (var node in notification.PublishedEntities)
                {
                    if (node?.ContentType?.Alias?.Equals("contactUs") ?? false)
                    {
                        var enableEmailFeedback = node.GetValue<bool>("enableEmailFeedback");
                        var sendGridAPIKey = node.GetValue<string>("sendGridAPIKey");
                        var from = node.GetValue<string>("from");
                        var to = node.GetValue<string>("to");
                        var subject = node.GetValue<string>("subject");

                        if (enableEmailFeedback && string.IsNullOrWhiteSpace(sendGridAPIKey) && string.IsNullOrWhiteSpace(from)
                            && string.IsNullOrWhiteSpace(to) && string.IsNullOrWhiteSpace(subject))
                        {
                            notification.CancelOperation(new EventMessage("Cancelled", "Please provide the Email setting data", EventMessageType.Error));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(ContactUsEmailSettingsNotification)}");
            }
        }
    }
}
