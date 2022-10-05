namespace MyBlog.Models.ExternalServiceModels.EmailServiceModels
{
    public class EmailRequest
    {
        public string Sender { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }
    }
}
