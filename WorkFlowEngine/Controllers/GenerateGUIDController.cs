using Microsoft.AspNetCore.Mvc;

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/GenerateGUID")]
    public class GenerateGUIDController : Controller
    {
        [HttpGet]
        public ActionResult<string> GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
