using MyBlog.ExternalServices.IServices.GoogleRecaptchaService;
using MyBlog.ExternalServices.Services.GoogleReCaptchaService;
using MyBlog.Models.AppSettingModels;

namespace MyBlog.ServiceCollections
{
    public static partial class ServiceCollections
    {
        public static IServiceCollection AddCustomGoogleReCaptchaService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<GoogleRecaptchaSettings>(config.GetSection(GoogleRecaptchaSettings.GoogleRecaptchaSetting));

            services.AddHttpClient<IGoogleRecaptchaService, GoogleRecaptchaService>();

            return services;
        }
    }
}
