using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyBlog.ExternalServices.IServices.EmailServices;
using MyBlog.ExternalServices.IServices.GoogleRecaptchaService;
using MyBlog.ExternalServices.Services.GoogleReCaptchaService;
using MyBlog.Models.AppSettings;
using MyBlog.Models.ExternalServiceModels.EmailServiceModels;
using MyBlog.Models.ExternalServiceModels.GoogleReCaptchaModels;
using MyBlog.Models.FeedbackModel;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyBlog.Controllers.FeedbackController
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IEmailService emailService;
        private readonly IOptions<EmailSettings> options;
        private readonly ILogger<FeedbackController> logger;
        private readonly UmbracoHelper umbracoHelper;
        private readonly IGoogleRecaptchaService googleRecaptchaService;
        public FeedbackController(IEmailService emailService, IOptions<EmailSettings> options,
            ILogger<FeedbackController> logger,
           UmbracoHelper umbracoHelper,
           IGoogleRecaptchaService googleRecaptchaService)
        {
            this.emailService = emailService;
            this.options = options;
            this.logger = logger;
            this.umbracoHelper = umbracoHelper;
            this.googleRecaptchaService = googleRecaptchaService;
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit(Feedback feedback)
        {
            try
            {
                GoogleReCaptcha googleReCaptchaResponse = await googleRecaptchaService
                    .SiteVerify(new GoogleReCaptcha { GoogleRecaptchaToken = feedback.GoogleRecaptchaToken });

                if (!googleReCaptchaResponse.success)
                    return new BadRequestResult();

                ContactUs UmbracoEmailSettings = umbracoHelper?.ContentAtRoot()?
                                                 .FirstOrDefault(x => x.IsDocumentType("home"))?
                                                 .Descendants()?
                                                 .FirstOrDefault(x => x.IsVisible() && x.IsDocumentType("contactUs")) as ContactUs;

                var emailRequest = new EmailRequest()
                {
                    Body = feedback?.Message,
                    From = string.IsNullOrWhiteSpace(UmbracoEmailSettings?.From) ? options.Value.From
                          : UmbracoEmailSettings.From,
                    To = string.IsNullOrWhiteSpace(UmbracoEmailSettings?.To) ? options.Value.To
                          : UmbracoEmailSettings.To,
                    Subject = string.IsNullOrWhiteSpace(UmbracoEmailSettings?.Subject) ? options.Value.Subject
                          : UmbracoEmailSettings.Subject
                };

                await emailService.SendEmail(emailRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, $"Error while processing {nameof(FeedbackController)}");
                return new BadRequestResult();
            }
        }
    }
}