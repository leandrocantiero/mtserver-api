using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mtvendors_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet("Get")]
        public ActionResult Get()
        {
            var ApplicationUrl = AppSettings.GetValue("ApplicationUrl");
            return Ok("MtServerApi online na url: " + ApplicationUrl);
        }
    }
}
