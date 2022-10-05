using MyBlog.Models.ExternalServiceModels.EmailServiceModels;

namespace MyBlog.ExternalServices.IServices.EmailServices
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailRequest emailRequest);
    }
}
