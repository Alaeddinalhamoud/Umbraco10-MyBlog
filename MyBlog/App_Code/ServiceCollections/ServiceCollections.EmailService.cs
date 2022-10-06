using MyBlog.ExternalServices.IServices.EmailServices;
using MyBlog.ExternalServices.Services.EmailServices;
using MyBlog.Models.AppSettings;

namespace MyBlog.ServiceCollections
{
    public static partial class ServiceCollections
    {
        public static IServiceCollection AddCustomEmailServices(this IServiceCollection services,
            IConfiguration config, IWebHostEnvironment env)
        {
            services.Configure<EmailSettings>(config.GetSection(EmailSettings.DefaultEmailSetting));

            if (env.IsDevelopment())
            {
                services.AddSingleton<IEmailService, LocalhostEmailService>();
            }
            else
            {
                services.AddSingleton<IEmailService, SendGridEmailService>();
            }

            return services;
        }
    }
}
