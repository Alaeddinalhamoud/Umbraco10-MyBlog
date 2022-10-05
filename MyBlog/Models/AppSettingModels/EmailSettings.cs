namespace MyBlog.Models.AppSettings
{
    public class EmailSettings
    {
        public const string DefaultEmailSetting = "DefaultEmailSettings";
        public string SendGridAPIKey { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
    }
}
