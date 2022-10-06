using MyBlog.Models.AppSettingModels;

namespace MyBlog.ServiceCollections
{
    public static partial class ServiceCollections
    {
        public static IServiceCollection AddCustomUmbracoMFAService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<UmbracoMFASettings>(config.GetSection(UmbracoMFASettings.UmbracoMFASetting));

            return services;
        }
    }
}
