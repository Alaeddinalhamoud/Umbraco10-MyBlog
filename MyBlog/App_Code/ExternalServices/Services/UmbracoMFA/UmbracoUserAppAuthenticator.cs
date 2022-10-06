using Google.Authenticator;
using Microsoft.Extensions.Options;
using MyBlog.Models.AppSettingModels;
using MyBlog.Models.UmbracoMFAModels;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;

//https://our.umbraco.com/documentation/reference/security/two-factor-authentication/

namespace MyBlog.ExternalServices.Services.UmbracoMFA
{
    public class UmbracoUserAppAuthenticator : ITwoFactorProvider
    {
        private readonly IUserService userService;
        private readonly IOptions<UmbracoMFASettings> options;
        public const string Name = "MyBlog";
        public string ProviderName => Name;

        public UmbracoUserAppAuthenticator(IUserService userService, IOptions<UmbracoMFASettings> options)
        {
            this.userService = userService;
            this.options = options;
        }

        public Task<object> GetSetupDataAsync(Guid userOrMemberKey, string secret)
        {

            var twoFactorAuthenticator = new TwoFactorAuthenticator();

            SetupCode setupInfo = twoFactorAuthenticator.GenerateSetupCode(options?.Value?.Issuer,
                                  userService.GetByKey(userOrMemberKey)?.Username,
                                  secret, false);

            return Task.FromResult<object>(new TwoFactorAuthInfo()
            {
                QrCodeSetupImageUrl = setupInfo.QrCodeSetupImageUrl,
                Secret = secret
            });
        }

        public bool ValidateTwoFactorPIN(string secret, string token) =>
            new TwoFactorAuthenticator().ValidateTwoFactorPIN(secret, token);

        public bool ValidateTwoFactorSetup(string secret, string token) => ValidateTwoFactorPIN(secret, token);
    }
}
