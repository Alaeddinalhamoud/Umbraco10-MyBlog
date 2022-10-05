using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models.FeedbackModel
{
    public class Feedback
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
