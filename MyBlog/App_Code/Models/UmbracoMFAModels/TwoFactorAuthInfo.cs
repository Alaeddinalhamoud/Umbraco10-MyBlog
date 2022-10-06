using System.Runtime.Serialization;

namespace MyBlog.Models.UmbracoMFAModels
{
    [DataContract]
    public class TwoFactorAuthInfo
    {
        [DataMember(Name = "qrCodeSetupImageUrl")]
        public string QrCodeSetupImageUrl { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }
    }
}
