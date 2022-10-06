using Newtonsoft.Json;

namespace MyBlog.Models.ExternalServiceModels.GoogleReCaptchaModels
{
    public partial class GoogleReCaptcha
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public string ValidatedDateTime { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
