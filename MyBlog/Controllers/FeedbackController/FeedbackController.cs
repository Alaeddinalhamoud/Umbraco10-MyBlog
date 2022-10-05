using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers.FeedbackController
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        public FeedbackController()
        {

        }
        public IActionResult Index()
        {

            return Ok();
        }
    }
}
