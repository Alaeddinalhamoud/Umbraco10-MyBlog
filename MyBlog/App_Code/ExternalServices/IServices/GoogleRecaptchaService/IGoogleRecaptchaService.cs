using MyBlog.Models.ExternalServiceModels.GoogleReCaptchaModels;

namespace MyBlog.ExternalServices.IServices.GoogleRecaptchaService
{
    public interface IGoogleRecaptchaService
    {
        Task<GoogleReCaptcha> SiteVerify(GoogleReCaptcha googleReCaptcha);
    }
}
