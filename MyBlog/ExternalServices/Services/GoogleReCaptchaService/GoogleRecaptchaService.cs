using Microsoft.Extensions.Options;
using MyBlog.ExternalServices.IServices.GoogleRecaptchaService;
using MyBlog.Models.AppSettingModels;
using MyBlog.Models.ExternalServiceModels.GoogleReCaptchaModels;
using System.Text.Json;

namespace MyBlog.ExternalServices.Services.GoogleReCaptchaService
{
    public class GoogleRecaptchaService : IGoogleRecaptchaService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<GoogleRecaptchaSettings> options;
        private readonly ILogger<GoogleRecaptchaService> logger;
        public GoogleRecaptchaService(HttpClient httpClient,
                                      IOptions<GoogleRecaptchaSettings> options,
                                      ILogger<GoogleRecaptchaService> logger)
        {
            this.httpClient = httpClient;
            this.options = options;
            this.logger = logger;
        }
        public async Task<GoogleReCaptcha> SiteVerify(GoogleReCaptcha googleReCaptcha)
        {
            try
            {
                var httpResponseMessage = await httpClient.GetStringAsync
              ($"https://www.google.com/recaptcha/api/siteverify?secret={options.Value.SecretKey}&response={googleReCaptcha.GoogleRecaptchaToken}");

                return JsonSerializer.Deserialize<GoogleReCaptcha>(httpResponseMessage);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, $"Error while processing {nameof(GoogleRecaptchaService)}");
                return new GoogleReCaptcha() { Success = false };
            }
        }
    }
}
